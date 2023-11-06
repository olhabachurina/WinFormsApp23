using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp23
{
    public partial class Form1 : Form
    {
        private ProgressBar progressBar;
        private Label statusLabel;
        private Button startButton;
        private System.Windows.Forms.Timer timer;
        private int progressValue;

        public Form1()
        {
            Text = "Пример ProgressBar";
            Width = 400;
            Height = 200;

            statusLabel = new Label
            {
                Text = DateTime.Now.ToString(),
                Dock = DockStyle.Top,
                AutoSize = true
            };

            progressBar = new ProgressBar
            {
                Dock = DockStyle.Fill,
                Style = ProgressBarStyle.Continuous
            };

            startButton = new Button
            {
                Text = "Начать",
                Dock = DockStyle.Bottom
            };
            startButton.Click += StartButton_Click;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // Установите интервал в миллисекундах
            timer.Tick += Timer_Tick;

            Controls.Add(statusLabel);
            Controls.Add(progressBar);
            Controls.Add(startButton);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            progressValue = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            statusLabel.Text = "Процесс выполняется...";

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressValue <= 100)
            {
                progressBar.Value = progressValue;
                progressValue++;
            }
            else
            {
                timer.Stop();
                statusLabel.Text = "Процесс завершен.";
            }
        }
    }
}

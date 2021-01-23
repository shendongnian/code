    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            using (var worker = new BackgroundWorker {
                WorkerReportsProgress = true })
            using (var progBar = new ProgressBar {
                Visible = false, Step = 1, Maximum = 100,
                Dock = DockStyle.Bottom })
            using (var btn = new Button { Dock = DockStyle.Top, Text = "Start" })
            using (var form = new Form { Controls = { btn, progBar } })
            {
                worker.ProgressChanged += (s,a) => {
                    progBar.Visible = true;
                    progBar.Value = a.ProgressPercentage;
                };
                worker.RunWorkerCompleted += delegate
                {
                    progBar.Visible = false;
                };
                worker.DoWork += delegate
                {
                    for (int i = 0; i < 100; i++)
                    {
                        worker.ReportProgress(i);
                        Thread.Sleep(100);
                    }
                };
                btn.Click += delegate
                {
                    worker.RunWorkerAsync();
                };
                Application.Run(form);
            }
        }
    }

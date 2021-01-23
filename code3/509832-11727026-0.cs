    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace BackgroundWorkerThreadExample
    {
        public partial class Form1 : Form
        {
            public delegate void ProgressUpdatedCallaback(ProgressUpdatedEventArgs progress);
            BackgroundWorker bw = new BackgroundWorker();
    
            public Form1()
            {
                InitializeComponent();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            }
    
            private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                DatabaseProcessor.ProgressUpdated += new DatabaseProcessor.ProgressUpdatedEvent(ProgressUpdated);
                DatabaseProcessor.GetData();
            }
    
            private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
            {
                bw.Dispose();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                bw.RunWorkerAsync();
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (bw.IsBusy == true)
                {
                    bw.CancelAsync();
                }
                bw.Dispose();
            }
    
            private void ProgressUpdated(ProgressUpdatedEventArgs progressUpdated)
            {
                if (InvokeRequired)
                {
                    Invoke(new ProgressUpdatedCallaback(this.UpdateProgress), new object[] { progressUpdated });
                }
                else
                {
                    UpdateProgress(progressUpdated);
                }
            }
    
            private void UpdateProgress(ProgressUpdatedEventArgs args)
            {
                ProgressBar pb = new ProgressBar();
                Label lb = new Label();
    
                if (args.Message == "")
                {
                    if (args.PBNum == 1)
                    {
                        pb = progressBar1;
                        lb = label1;
                    }
                    else if (args.PBNum == 2)
                    {
                        pb = progressBar2;
                        lb = label2;
                    }
    
                    if (pb.Maximum != args.Total)
                    {
                        // initial setup
                        pb.Minimum = 0;
                        pb.Maximum = args.Total;
                        pb.Style = ProgressBarStyle.Continuous;
                    }
    
                    pb.Value = args.Processed;
    
                    if (args.Total > 0)
                    {
                        double progress = args.Processed / (args.Total * 1.0);
                        lb.Text = progress.ToString("P2");
                    }
                }
                else
                {
                    this.richTextBox1.Text += args.Message;
                    //Goto last line
                    this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
                    this.richTextBox1.ScrollToCaret();
                }
                //Application.DoEvents();
            }
        }
    
        public static class DatabaseProcessor
        {
            public delegate void ProgressUpdatedEvent(ProgressUpdatedEventArgs progressUpdated);
            public static event ProgressUpdatedEvent ProgressUpdated;
    
            public static void GetData()
            {
                int total = 126;
                Random randomGenerator = new Random();
                for (int i = 0; i < total; i++)
                {
                    // Do some processing here
                    double delay = (double)randomGenerator.Next(2) + randomGenerator.NextDouble();
                    int sleep = (int)delay * 1000;
                    System.Threading.Thread.Sleep(sleep);
                    RaiseEvent(1, total, i + 1);
                    RaiseEvent(0, 0, 0, string.Format("Processing Item {0} \r\n", i + 1));
    
                    for (int ii = 0; ii < total; ii++)
                    {
                        // Do some processing here
                        double delay2 = (double)randomGenerator.Next(2) + randomGenerator.NextDouble();
                        int sleep2 = (int)delay2 * 10;
                        System.Threading.Thread.Sleep(sleep2);
                        RaiseEvent(2, total, ii + 1);
                    }
                }
            }
    
            private static void RaiseEvent(int pbNum, int total, int current, string message = "")
            {
                if (ProgressUpdated != null)
                {
                    ProgressUpdatedEventArgs args = new ProgressUpdatedEventArgs(pbNum, total, current, message);
                    ProgressUpdated(args);
                }
            }
        }
    
        public class ProgressUpdatedEventArgs : EventArgs
        {
            public ProgressUpdatedEventArgs(int pbNum, int total, int progress, string message = "")
            {
                this.PBNum = pbNum;
                this.Total = total;
                this.Processed = progress;
                this.Message = message;
            }
            public string Message { get; private set; }
            public int PBNum { get; private set; }
    
            public int Processed { get; private set; }
            public int Total { get; private set; }
        }
    }

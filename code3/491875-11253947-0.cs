    using System;
    using System.ComponentModel;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerSupportsCancellation = false;
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler(bw_DoWork);
                worker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                worker.RunWorkerAsync();
                Console.WriteLine("I'm Done!");
                Console.ReadKey(true);
            }
    
            private static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                Console.WriteLine("Completed");
            }
    
            private static void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {            
            }
    
            private static void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                System.Threading.Thread.Sleep(5000);
            }
        }
    }

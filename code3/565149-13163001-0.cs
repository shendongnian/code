    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Threading;
    
    class Program
    {
        static void Main(string[] args)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
            {
                try
                {
                    throw new FileNotFoundException();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("FileNotFoundException caught");
                }
            };
    
            worker.RunWorkerCompleted += (s, e) =>
            {
                if (e.Error != null)
                    Console.WriteLine("RunWorkerCompleted error is {0}", e);
            };
    
            worker.RunWorkerAsync();
            while (worker.IsBusy)
                Thread.Sleep(1);
        }
    }

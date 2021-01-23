    class Program
    {
        static void Main(string[] args)
        {            
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            
            stopWatch.Start();
            Thread.Sleep(10000);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes + 45 , ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }

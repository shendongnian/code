    class Program
    {
        // hardcoded, it's just a test:
        static int activeProcesses = 0;
        static int finishedProcesses = 0;
        static int maxProcesses = 5;
        static int runProcesses = 20;
    
        static string file = @"c:\tmp\dummyDelay.exe";
    
        static void Main(string[] args)
        {
            Random rnd = new Random();
    
            while (activeProcesses + finishedProcesses < runProcesses)
            {
                if (activeProcesses < maxProcesses)
                {
                    Process p = new Process();
                    p.EnableRaisingEvents = true;
                    p.Exited += new EventHandler(pExited);
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.StartInfo.FileName = file;
                    p.StartInfo.Arguments = rnd.Next(2000, 5000).ToString();
                    p.Start();
                    Console.WriteLine("Started: {0}", p.Id.ToString());
                    activeProcesses++;
                }
            }
            
        }
    
        static void pExited(object sender, EventArgs e)
        {
            Console.WriteLine("Finished: {0}", ((Process)sender).Id.ToString());
            ((Process)sender).Dispose();
            activeProcesses--;
            finishedProcesses++;
        }
    }

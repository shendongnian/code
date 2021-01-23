        static void Main(string[] args)
        {            
            Process pr;
            pr = new Process();
            pr.StartInfo = new ProcessStartInfo(@"notepad.exe");
            pr.EnableRaisingEvents = true; // first thing
            pr.Exited += pr_Exited; // second thing
            pr.Start();
            Console.WriteLine("press [enter] to exit");
            Console.ReadLine();
           
            Console.ReadKey(); 
        }
        static void pr_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("exited");
        }

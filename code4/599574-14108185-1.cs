    static void Main(string[] args)
        {
            Program p = new Program();
            Thread t = new Thread(new ThreadStart(p.startActivityMonitoring));
            t.Start();
            Console.Writeline("Press enter to exit");
            Console.ReadLine();
        }

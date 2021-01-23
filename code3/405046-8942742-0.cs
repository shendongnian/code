        static class Program
        {
            [DllImport("kernel32.dll")]
            private static extern bool AllocConsole(); 
    
            [STAThread]
            static void Main()
            {
                bool bConsoleMode = false;
                if (bConsoleMode)
                {
                    AllocConsole();
                    Console.WriteLine("This is the console");
                    Console.ReadLine();
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }
        }

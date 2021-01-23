        static class Program
        {
            [DllImport("kernel32.dll")]
            static extern bool AttachConsole(int dwProcessId);
            private const int ATTACH_PARENT_PROCESS = -1;
        
        
            [DllImport("kernel32.dll")]
            private static extern bool AllocConsole(); 
        
             [STAThread]
            static void Main()
            {
                bool bParentConsoleMode = true;
                bool bUsingOwnConsole = true;
                if (bParentConsoleMode)
                {
                   AttachConsole(ATTACH_PARENT_PROCESS);
                    Console.WriteLine("Using parent console");
                    Console.ReadLine();
                    
                }
                else if (bUsingOwnConsole)
                {
                    AllocConsole();
                    Console.WriteLine("Using own console");
                    Console.ReadLine();
                }
                else //gui mode
                {
                    Console.WriteLine("This is cool");
        
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }
        }

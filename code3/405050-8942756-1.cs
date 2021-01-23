     Console.WriteLine("started");
     if (args.Length == 0)
     {
         ProcessForConsole(argsParser);
     }
     else
     {
         NativeMethods.FreeConsole();
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new Form1());                
     }    
.
.
.
.
     [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int FreeConsole();

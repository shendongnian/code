    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        /* PUT THIS LINE IN YOUR CLASS PROGRAM MAIN() */           
            AppDomain.CurrentDomain.AssemblyResolve += (sender, arg) => { if (arg.Name.StartsWith("YOURDLL")) return Assembly.Load(Properties.Resources.YOURDLL); return null; }; 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

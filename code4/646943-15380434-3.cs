    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WindowlessApplicationContext());
        }
    }
    /// <summary>
    /// The window less application context.
    /// </summary>
    internal class WindowlessApplicationContext : ApplicationContext
    {
        /// <summary>
        /// Standard constructor.
        /// </summary>
        public WindowlessApplicationContext()
        {
            try
            {
                //Your code
                
            }
            // you mayy add catch here
            finally
            {
                //Close process
                Environment.Exit(0);
            }
        }
    }

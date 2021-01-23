    public class SingleInstanceApplication : WindowsFormsApplicationBase
    {
        private SingleInstanceApplication()
        {
            IsSingleInstance = true;
        }
    
        public static void Run(Form form)
        {
            var app = new SingleInstanceApplication
            {
                MainForm = form
            };
    
            app.StartupNextInstance += (s, e) => e.BringToForeground = true;
    
            app.Run(Environment.GetCommandLineArgs());
        }
    }

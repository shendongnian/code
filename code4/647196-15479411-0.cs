    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // check if it is the first instance or not
            // do logic
            // get arguments
            var cmdLineArgs = e.Args;
            if (thisisnotthefirst)
            {
                // logic interprocess
                // do logic
                // exit this instance
                Application.Current.Shutdown();
                return;
            }
            
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            // may be some release needed for your single instance check
            base.OnExit(e);
        }
    }

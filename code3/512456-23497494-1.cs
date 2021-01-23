    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            foreach (string arg in e.Args)
            {
                // TODO: whatever
            }
            base.OnStartup(e);
        }
    }

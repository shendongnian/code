    [STAThread]
    public static void Main()
    {
        if (SingleInstance<App>.InitializeAsFirstInstance(UNIQUE))
        {
            var application = new App();
            application.InitializeComponent();
            application.Run();
            SingleInstance<App>.Cleanup();
        }
    }
    
    public bool SignalExternalCommandLineArgs(IList<string> args)
    {
        // Use arguments
        return true;
    }

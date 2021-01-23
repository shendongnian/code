    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
    Version version = assembly.GetName().Version;
    if (version.ToString() != Properties.Settings.Default.ApplicationVersion)
    {
        copyLastUserConfig(version);
    }

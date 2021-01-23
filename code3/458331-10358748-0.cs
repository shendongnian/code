    if (SandboxDomain == null)
    {
    	var appDomainSetup = new AppDomainSetup();
    	string appBase = typeof(CompilerService).Assembly.CodeBase;
    
    	//Added the following line
    	appBase = new Uri(appBase).LocalPath;
    	appDomainSetup.ApplicationBase = Path.GetDirectoryName(appBase);
    	var evidence = AppDomain.CurrentDomain.Evidence;
    	SandboxDomain = AppDomain.CreateDomain("Sandbox", evidence, appDomainSetup);
    }

    private void PublishProject()
    {
    
    Engine engine = new Engine();
                FileLogger logger = new FileLogger();
                logger.Parameters = @"logfile=C:\temp\publish.log";
                engine.RegisterLogger(logger);
    
                BuildPropertyGroup bpg = new BuildPropertyGroup();
                bpg.SetProperty("OutDir", @"C:\outdir\");
                bpg.SetProperty("Configuration", "Debug");
                bpg.SetProperty("Platform", "AnyCPU");
                bpg.SetProperty("DeployOnBuild", "true");
                bpg.SetProperty("DeployTarget", "Package");
                bpg.SetProperty("PackageLocation", @"$(OutDir)\MSDeploy\Package.zip");
                bpg.SetProperty("_PackageTempDir", @"C:\temp\");
    
    
                bool success = engine.BuildProjectFile(GetProjectFileName(), null, bpg);
    
                if (success)
                    Console.WriteLine("Success!");
                else
                    Console.WriteLine(@"Build failed - look at c:\temp\publish.log for details");
    
                engine.UnloadAllProjects();
                engine.UnregisterAllLoggers();
    
    }

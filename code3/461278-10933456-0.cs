    // Create a logger.
    FileLogger logger = new FileLogger();
    logger.Parameters = @"logfile=Northwind.msbuild.log";
    // Set up properties.
    var projects = ProjectCollection.GlobalProjectCollection;
    projects.SetGlobalProperty("Configuration", "Debug");
    projects.SetGlobalProperty("SqlPublishProfilePath", @"Northwind.publish.xml");
    // Load and build project.
    var dbProject = ProjectCollection.GlobalProjectCollection.LoadProject(@"Northwind.sqlproj");
    dbProject.Build(new[]{"Build", "Publish"}, new[]{logger});

    var solutionProjects = 
        from buildLevel in Enumerable.Range(0, 10)
        let buildLevelType = "BuildLevel" + buildLevel
        let buildLevelItems = slnProj.GetItems(buildLevelType)
        from buildLevelItem in buildLevelItems
        let include = buildLevelItem.EvaluatedInclude
        where !(include.Contains("UnitTests") || include.Contains("Unit Tests"))            
        select new { Include=include, Project = pc.LoadProject(Path.Combine(basePath, include))};
    
    foreach (var projectPair in solutionProjects)
    {
        var project = projectPair.Project;
        string.Format("OutDir={0}", project.ExpandString("$(OutDir)")).Dump();
        string.Format("OutputPath={0}", project.ExpandString("$(OutputPath)")).Dump();
        continue;
        var include = projectPair.Include;
        var outputPath = outputDir;
        project.SetProperty("OutputPath", outputPath);
        var projectLogger = new BasicFileLogger();    
        var tempProjectLogPath = Path.GetTempFileName();
        projectLogger.Parameters = tempProjectLogPath ;
    
        Console.WriteLine("Building project:" + project.DirectoryPath);
        var buildOk = project.Build("Build", new[]{projectLogger});
        if(buildOk)
        {
            Console.WriteLine("Project build success!");
        } 
        else
        {
            var logDump = File.ReadAllText(tempProjectLogPath);
            logDump.Dump();
            throw new Exception("Build failed");
        }
    }

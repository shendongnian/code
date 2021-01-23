    var basePath = "path-to-where-source-is";
    var outputDir = "path-to-output";
    
    // Setup some properties that'll apply to all projs
    var pc = Microsoft.Build.Evaluation.ProjectCollection.GlobalProjectCollection;
    pc.SetGlobalProperty("Configuration", "Debug");
    pc.SetGlobalProperty("Platform", "Any CPU");
    pc.SetGlobalProperty("OutDir", outputDir);
    
    // Generate the metaproject that represents a given solution file
    var slnProjText = SolutionWrapperProject.Generate(
        Path.Combine(basePath, "NAME-OF-SOLUTION-FILE.sln"), 
        "4.0", 
        null);
    // It's now a nice (well, ugly) XML blob, so read it in
    using(var srdr = new StringReader(slnProjText))
    using(var xrdr = XmlReader.Create(srdr))
    {
        // Load the meta-project into the project collection        
        var slnProj = pc.LoadProject(xrdr, "4.0");
        // Slice and dice the projects in solution with LINQ to
        // get a nice subset to work with
        var solutionProjects = 
            from buildLevel in Enumerable.Range(0, 10)
            let buildLevelType = "BuildLevel" + buildLevel
            let buildLevelItems = slnProj.GetItems(buildLevelType)
            from buildLevelItem in buildLevelItems
            let include = buildLevelItem.EvaluatedInclude
            where !include.Contains("Some thing I don't want to build")
            select new 
            { 
                Include=include, 
                Project = pc.LoadProject(Path.Combine(basePath, include))
            };
        // For each of them, build em!
        foreach (var projectPair in solutionProjects)
        {
            var project = projectPair.Project;
            var include = projectPair.Include;
            var outputPath = outputDir;
            project.SetProperty("OutputPath", outputPath);
            Console.WriteLine("Building project:" + project.DirectoryPath);
            var buildOk = project.Build("Build");
            if(buildOk)
            {
                Console.WriteLine("Project build success!");
            } 
            else
            {
                throw new Exception("Build failed");
            }
        }
    }

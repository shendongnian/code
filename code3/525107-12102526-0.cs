        Dictionary<string, string> globalProperties = new Dictionary<string, string>();
        globalProperties.Add("Configuraion", "Debug");
        globalProperties.Add("Platform", "AnyCPU");
        ProjectCollection pc = new ProjectCollection(globalProperties);
        Project sln = pc.LoadProject(@"MyProject.csproj", "4.0");
        foreach (ProjectItem pi in sln.Items)
        {
            if (pi.ItemType == "ProjectReference")
            {
                Console.WriteLine(pi.EvaluatedInclude);
            }
        }

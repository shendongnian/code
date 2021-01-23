        Dictionary<string, string> globalProperties = new Dictionary<string, string>();
        globalProperties.Add("Configuraion", "Debug");
        globalProperties.Add("Platform", "AnyCPU");
        ProjectCollection pc = new ProjectCollection(globalProperties);
        Project sln = pc.LoadProject(@"my_directory\My_solution_name.sln.metaproj", "4.0");
        foreach (ProjectItem pi in sln.Items)
        {
            if (pi.ItemType == "ProjectReference")
            {
                Project p = pc.LoadProject(pi.EvaluatedInclude);
                ProjectProperty pp = p.GetProperty("OutputPath");
                if (pp != null)
                {
                    Console.WriteLine("Project=" + pi.EvaluatedInclude + " OutputPath=" + pp.EvaluatedValue);
                }
            }
        }

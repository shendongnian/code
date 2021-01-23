    using Roslyn.Services;
    using Roslyn.Services.Host;
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
            var solution = Solution.Create(SolutionId.CreateNewId()).AddCSharpProject("Foo", "Foo").Solution;
            var workspaceServices = (IHaveWorkspaceServices)solution;
            var projectDependencyService = workspaceServices.WorkspaceServices.GetService<IProjectDependencyService>();
            var assemblies = new List<Stream>();
            foreach (var projectId in projectDependencyService.GetDependencyGraph(solution).GetTopologicallySortedProjects())
            {
                using (var stream = new MemoryStream())
                {
                    solution.GetProject(projectId).GetCompilation().Emit(stream);
                    assemblies.Add(stream);
                }
            }
        }
    }

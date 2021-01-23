     foreach (SolutionContext solutionContext in _applicationObject.Solution.SolutionBuild.ActiveConfiguration.SolutionContexts)
     {
         if (solutionContext.ShouldBuild)
          activeProjects.Add(solutionContext.ProjectName);
      }

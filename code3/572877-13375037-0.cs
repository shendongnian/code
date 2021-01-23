    public IEnumerable<string> SolutionFiles()
    {
        Solution2 soln = (Solution2)_applicationObject.Solution;
        foreach (Project project in soln.Projects)
        {
            foreach (ProjectItem  item in project.ProjectItems)
            {
                yield return item.FileNames[0];
            }
        }
    }

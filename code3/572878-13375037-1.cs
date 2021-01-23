    public IEnumerable<ProjectItem> Recurse(ProjectItems i)
    {
        if (i!=null)
        {
            foreach (ProjectItem j in i)
            {
                foreach (ProjectItem k in Recurse(j))
                {
                    yield return k;
                }
            }
            
        }
    }
    public IEnumerable<ProjectItem> Recurse(ProjectItem i)
    {
        yield return i;
        foreach (ProjectItem j in Recurse(i.ProjectItems ))
        {
            yield return j;
        }
    }
    public IEnumerable<ProjectItem> SolutionFiles()
    {
        Solution2 soln = (Solution2)_applicationObject.Solution;
        foreach (Project project in soln.Projects)
        {
            foreach (ProjectItem item in Recurse(project.ProjectItems))
            {
                yield return item;
            }
        }
    }

    List<int?> pids = new List<int?>() { 2, 4, 3 };
    
    List<Project> projects = new List<Project>() { 
        new Project(1), new Project(2), 
        new Project(3), new Project(4), 
        new Project(5), new Project(null) };
    
    List<Project> sortedProjectsAccordingToPids = projects
        .Select(project => new Tuple<Project, int?>
            (project, pids.IndexOf(project.ID)))
        .Where(projectTuple => projectTuple.Item2 > -1)
        .OrderBy(projectTuple => projectTuple.Item2)
        .Select(projectTuple => projectTuple.Item1)
        .ToList<Project>();

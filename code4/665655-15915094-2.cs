    List<int?> pids = new List<int?>() { 2, 4, 3 };
    
    List<Project> projects = new List<Project>() { 
        new Project(1), new Project(2), 
        new Project(3), new Project(4), 
        new Project(5), new Project(null) };
    
    List<Project> sortedProjectsByPids = pids
        .Select(pid => projects.First(p => p.ID == pid))
        .ToList<Project>();

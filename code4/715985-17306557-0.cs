    var projects = 
        orderedProjects
            .Select(o => projects.SingleOrDefault(p => p.ProjectNbr == o.ProjectNbr))
            .Where(x => x != null) // This is only necessary if there can be
                                   // ProjectNbrs in orderedProjects that are not in
                                   // projects
            .ToList();

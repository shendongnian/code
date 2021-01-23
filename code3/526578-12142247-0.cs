        List<Activity> Activities = new List<Activity>(); 
        Activities.Add(new Activity() 
            { Name = "Activity 1", Complete = true, 
                DueDate = startDate.AddDays(4), Project = "Project 1" });
        Activities.Add(new Activity() 
            { Name = "Activity 2", Complete = true, 
                DueDate = startDate.AddDays(5), Project = "Project 2" });
    
    followed by the following to get the data in your CollectionViewSource
    
        var result = from act in Activities group act by act.Project into grp orderby grp.Key select grp;
        cvsActivities.Source = result;
    
    Or you can build a hierarchy using object properties like this...
    
    List<Project> Projects = new List<Project>();
    
    Project newProject = new Project();
    newProject.Name = "Project 1";
    newProject.Activities.Add(new Activity() 
        { Name = "Activity 1", Complete = true, DueDate = startDate.AddDays(4) });
    newProject.Activities.Add(new Activity() 
        { Name = "Activity 2", Complete = true, DueDate = startDate.AddDays(5) });
    newProject.Activities.Add(new Activity() 
        { Name = "Activity 3", Complete = false, DueDate = startDate.AddDays(7) });
    newProject = new Project();
    newProject.Name = "Project 2";
    newProject.Activities.Add(new Activity() 
        { Name = "Activity A", Complete = true, DueDate = startDate.AddDays(2) });
    newProject.Activities.Add(new Activity() 
        { Name = "Activity B", Complete = false, DueDate = startDate.AddDays(3) });
    cvsProjects.Source = Projects;

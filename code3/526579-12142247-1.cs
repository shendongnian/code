    List<Activity> Activities = new List<Activity>(); 
    Activities.Add(new Activity() 
        { Name = "Activity 1", Complete = true, 
                DueDate = startDate.AddDays(4), Project = "Project 1" });
    Activities.Add(new Activity() 
        { Name = "Activity 2", Complete = true, 
                DueDate = startDate.AddDays(5), Project = "Project 2" });
    

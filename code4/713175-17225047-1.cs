    var input = new[] 
    {
        new { Group = "Group1", Type = 1 },
        new { Group = "Group2", Type = 2 },
        new { Group = "Group3", Type = 1 },
        new { Group = "Group4", Type = 1 },
        new { Group = "Group5", Type = 1 },
        new { Group = "Group6", Type = 2 },
        new { Group = "Group7", Type = 3 },
    };
    
    var results = input.AlternateGroups(x => x.Type);
    // Group1 1 
    // Group2 2 
    // Group7 3 
    // Group3 1 
    // Group6 2 
    // Group7 3 
    // Group4 1 
    // Group2 2 
    // Group7 3 
    // Group5 1 
    // Group6 2 
    // Group7 3 

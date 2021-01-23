    List<String> l_lstNames = new List<String> { "A1", "A3", "A2", "A4", "A0" };
    
    List<Test> l_lstStudents = new List<Test> 
    							{ new Test { Age = 20, Name = "A0" }, 
    							  new Test { Age = 21, Name = "A1" }, 
    							  new Test { Age = 22, Name = "A2" }, 
    							  new Test { Age = 23, Name = "A3" }, 
    							  new Test { Age = 24, Name = "A4" }, 
    							};
    // We transform the list in a dictionary to make it faster to access.
    // The first Select creates a new object with the index of the name and 
    // the ToDictionary creates the Dictionary.
    var dict = l_lstNames.Select((p, i) => new { Index = i, Name = p })
                         .ToDictionary(p => p.Name, p => p.Index);
    
    // We sort it. This works because 3 < 5 => 3 - 5 < 0, 5 > 3 => 5 - 3 > 0, 5 == 5 => 5 - 5 == 0
    l_lstStudents.Sort((p, q) => dict[p.Name] - dict[q.Name]);
    // We could do something like and it would be clearer.
    l_lstStudents.Sort((p, q) => dict[p.Name].CompareTo(dict[q.Name]));

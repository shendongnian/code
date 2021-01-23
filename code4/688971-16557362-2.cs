    var list = new[] { new { Number = 0, Name = "Name1" } }.ToList(); //just to create a 
                                                      //list of anonymous type object
    list.Clear();
    
    for (int i = 0; i < 10; i++)
    {
        list.Add(new { Number = i, Name = string.Concat("name",i) });
    }

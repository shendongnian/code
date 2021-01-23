    //I guess you can get the string representation of the column value
    string value = "/One/Two/Three/Four/"; 
    List<string> parameters = new List<string> { "Two", "Three" };
    
    bool result = value.Split('/')
                       .Intersect(parameters)
                       .Any();

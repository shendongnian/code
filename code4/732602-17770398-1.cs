    // somewhere near the start in your code initialize the dictionary 
    var dict = new Dictionary<string, ObjectEx>();
    
    // later on you can dynamically add an Object to the Dictionary
    // newUsersName is the so called Index
    string newUsersName = Console.ReadLine();
    dict.Add(newUsersName, new ObjectEx());
    
    // if you need to get hold of that object again use the Index
    // myObj is a ObjectEx type
    var myObj = dict[newUsersName];

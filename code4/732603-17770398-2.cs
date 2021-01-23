    // somewhere near the start in your code initialize the dictionary 
    var dict = new Dictionary<string, Person>();
    
    // later on you can dynamically add an Object to the Dictionary
    // newUsersName is the so called Index
    string newUsersName = Console.ReadLine();
    dict.Add(newUsersName, new Person());
    
    // if you need to get hold of that object again use the Index
    // myObj is a Person type
    var myObj = dict[newUsersName];
    // assume Person has an Age property 
    myObj.Age = 20;
    // show all Persons now in the dictionary
    foreach(var username in dict.Keys)
    {
        Console.WriteLine(username);
        var pers = dict[username];
        Console.WriteLine("{0} is {1} years old", username, pers.Age ); 
    }

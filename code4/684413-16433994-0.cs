    Dictionary<int, string> userCredentials = new Dictionary<int, string>
    {
        {807301, "Miami"},
        {992032, "LosAngeles"},
        {123144, "NewYork"},
        {123432 , "Dallas"},
    };
    
    int userName = ...;
    string password = ...;
    
    string foundPassword;
    if (userCredentials.TryGetValue(userName, out foundPassword) && (foundPassword == password))
    {
        Console.WriteLine("User authenticated");
    }
    else
    {
        Console.WriteLine("Invalid password");
    }

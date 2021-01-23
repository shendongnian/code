    //building the user "database" each pair is <user,password>
    Dictionary<string, string> users = new Dictionary<string, string>();
    users.Add("John", "123456");
    //Here you should add more users in the same way...
    //But i would advise reading them from out side the code (SQL database for example).
    
    Console.Writeline("Enter your Name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter your Passward");
    string password = Console.ReadLine();
    
    if (users.ContainsKey(name) && users[name] == password)
    {
        Console.WriteLine("You are logged in");
    }
    else
    {
        Console.WriteLine("Incorrect name or password");
    }
    
    Console.ReadLine();

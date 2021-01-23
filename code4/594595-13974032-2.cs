    static void Main(string[] args)
    {
       var userName = "Alice";
       var task = CreateUserTask(userName);
       // ...
    }
    
    static Task CreateUserTask(string taskUserName)
    {
        return new Task(() =>
        {
            Console.WriteLine("User is: " + taskUserName);
        });
    }

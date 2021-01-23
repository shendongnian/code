    class Program
    {
        static void Main(string[] args)
        {
    
            users allUsers = new users();
            allUsers.user = new usersUser[3];
            usersUser userConfig = new usersUser();
    
            userConfig.username = "Jim";
            allUsers.user[0] = userConfig;
            Console.WriteLine(allUsers.user[0].username);
    
            userConfig = new usersUser();
            userConfig.username = "Frank";
            allUsers.user[1] = userConfig;
            Console.WriteLine(allUsers.user[1].username);
    
            userConfig = new usersUser();
            userConfig.username = "James";
            allUsers.user[2] = userConfig;
            Console.WriteLine(allUsers.user[2].username);
    
            Console.WriteLine("");
    
            Console.WriteLine(allUsers.user[0].username);
            Console.WriteLine(allUsers.user[1].username);
            Console.WriteLine(allUsers.user[2].username);
    
            Console.ReadLine();
        }
    }

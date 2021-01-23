    private IEnumerable<User> ReadUsersFromTextFile(string path)
    {
        var users = new List<User>();
        using(var sr = new StringReader(path)
        {
            do
            {
                var strings = sr.ReadLine().split(';');                 
                var user = new User();
                user.Name = strings[0];
                user.Age = strings[1];
                users.Add(user);
            }while(!sr.EndOfStream)
        }
        return users;
    }

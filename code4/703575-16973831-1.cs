    // Somewhere to put the data - a Dictionary is my first choice here
    Dictionary<string, UserRecord> users = new Dictionary<string, UserRecord>();
    // Don't forget to use 'using' where appropriate
    using (TextReader userfile = File.OpenText(userDataFile))
    {
        string srcline;
        while ((srcline = userfile.ReadLine()) != null)
        {
            UserRecord user = UserRecord.Parse(line);
            if (user != null)
                users[user.Name] = user;
        }
    }

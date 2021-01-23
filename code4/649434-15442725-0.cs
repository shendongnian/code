        users = new Dictionary<string, User>();
        System.Console.WriteLine("users.ul exists: " + File.Exists("users.ul"));
        // Check the status of users.ul. If it exists, fill the user dictionary with its data.
        if (File.Exists("users.ul"))
        {
			var lines = File.ReadAllLines("users.ul");
            // Usernames are listed first in users.ul, and are followed by a period and then the password associated with that username.
            foreach(var line in lines)
                string[] splitted = line.Split('.');
                string un = splitted[0].Trim();
                string pass = splitted[1].Trim();
                User u = new User(un, pass);
                // Add the username and User object to the dictionary
                users.Add(un, u);
            }
            System.Console.WriteLine("count: " + lines.Count());
            reader.Close();
        }

            System.Console.WriteLine("users.ul exists: " + File.Exists("users.ul"));
            // Check the status of users.ul. If it exists, fill the user dictionary with its data.
            if (File.Exists("users.ul")) {
                var lines = File.ReadAllLines("users.ul");
                // Usernames are listed first in users.ul, and are followed by a period and then the password associated with that username.
                var users = lines.Select(o => o.Split('.'))
                            .Where(o => o.Length == 2)
                            .Select(o => new User(o[0].Trim(), o[1].Trim());
                System.Console.WriteLine("count: " + users.Count());
            }

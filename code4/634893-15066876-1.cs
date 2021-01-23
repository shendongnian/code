            StreamReader reader = new StreamReader("sample.txt");
            string x = reader.ReadToEnd();
            List<string> users = new List<string>();
            int numberOfUsers;
            Regex regex = new Regex(@"(U|u)ser:(?<username>.*?) appGUID");
            MatchCollection matches = regex.Matches(x);
            foreach (Match match in matches)
            {
                string user = match.Groups["username"].ToString().Trim();
                if (!users.Contains(user)) users.Add(user);
            }
            numberOfUsers = users.Count;

            StreamReader reader = new StreamReader("sample.txt");
            string x = reader.ReadToEnd();
            List<string> users = new List<string>();
            int numberOfUsers;
            Regex regex = new Regex(@"(U|u)ser:(?<username>.*?) appGUID");
            var matches = regex.Matches(x);
            foreach (var match in matches)
            {
                if (!users.Contains(match.ToString())) users.Add(match.ToString());
            }
            numberOfUsers = users.Count;

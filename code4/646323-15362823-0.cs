            IEnumerable<string> textLines = Directory.GetFiles(@"C:\Users\karansha\Desktop\Unique_Express\", "*.*")
                                                     .Select(filePath => File.ReadLines(filePath))
                                                     .SelectMany(line => line);
            List<string> users = new List<string>();
            textLines.ToList().ForEach(textLine =>
            {
                Regex regex = new Regex(@"User:\s*(?<username>.*?)\s");
                MatchCollection matches = regex.Matches(textLine);
                foreach (Match match in matches)
                {
                    var user = match.Groups["username"].Value;
                    if (!users.Contains(user)) users.Add(user);
                }
            });
            int numberOfUsers = users.Count(name => name.Length < 15);
            Console.WriteLine("Unique_Users_Express=" + numberOfUsers);

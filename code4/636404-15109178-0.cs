    StreamReader reader = new StreamReader(@"test file path");
    string x = reader.ReadToEnd();
    List<string> users = new List<string>();
    Regex regex = new Regex(@"User:\s*(?<username>.*?)\s+appGUID");
    MatchCollection matches = regex.Matches(x);
    foreach (Match match in matches) {
        var user = match.Groups["username"].Value;
        if (!users.Contains(user)) users.Add(user);
    }
    int numberOfUsers = users.Count;
    Console.WriteLine(numberOfUsers);

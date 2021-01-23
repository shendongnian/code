    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    string s = "username=bill&password=mypassword";
    foreach (string x in s.Split('&'))
    {
        string[] values = x.Split('=');
        dictionary.Add(values[0], values[1]);
    }

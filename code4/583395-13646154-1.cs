    string tmp = "abc 123 \"Edk k3\" String;";
    
    MatchCollection m = Regex.Matches(tmp, @"""(.*?)""|([^ ]+)");
    
    foreach (Match s in m) {
      Console.WriteLine(s.Groups[1].Value.Replace(" ", "") + s.Groups[2].Value);
    }

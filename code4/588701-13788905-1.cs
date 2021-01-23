    string text = "The name of my dog is %x% and he has %y% years old.";
    
    Dictionary<string, int> keys =
      Regex.Matches(text, @"%(\w+)%")
      .Cast<Match>()
      .GroupBy(m => m.Groups[1].Value)
      .ToDictionary(g => g.Key, g => g.Count());
    
    foreach (KeyValuePair<string,int> key in keys) {
      Console.WriteLine("{0} occurs {1} time(s).", key.Key, key.Value);
    }

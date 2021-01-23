    string s = "[1]Ali ahmadi,[2]Mohammad Razavi";
    Regex regex = new Regex(@"\[(\d+)\]", RegexOptions.Compiled);
    foreach (Match match in regex.Matches(s))
    {
      Console.WriteLine(match.Groups[1].Value);
    }

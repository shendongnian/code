    string[] lines3;
    List<string> lines2 = new List<string>();
    lines3 = Regex.Split(s1, @"\s*,\s*");
    foreach (string s in lines3) {
      if (!lines2.Contains(s)) {
        lines2.Add(s);
      }
    }

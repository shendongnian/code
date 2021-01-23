    string input = "asdf,asdf;asdf.asdf,asdf,asdf";
    var values = new List<string>();
    int pos = 0;
    foreach (Match m in Regex.Matches(input, "[,.;]")) {
      values.Add(input.Substring(pos, m.Index - pos));
      values.Add(m.Value);
      pos = m.Index + m.Length;
    }
    values.Add(input.Substring(pos));

    const string pattern = "ref_result\">([^<]*)";
    Regex rgx = new Regex(pattern, RegexOptions.Compiled);
    var text = SantinizeOutput(result.result);
    MatchCollection matches = rgx.Matches(text);
    List<string> resultsList = new List<string>(matches.Count);
    for(int i=0; i<resultsList.Length; i++) {
      resultsList.Add(matches[i].Groups[1].Value);
    }
    private string SantinizeOutput(string input) {
      var text = input.Replace("\n", "").Replace("\r", "");
      return Regex.Replace(text, "\\s+", " ");
    }

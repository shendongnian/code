      string input = "<p style="">ss</p>  <b>Issues</b>";
      string pattern = "(?<=\>)ss(?=\<)";
      string replacement = "<u>ss</u>";
      Regex rgx = new Regex(pattern);
      string result = rgx.Replace(input, replacement);
      Console.WriteLine("Original String: {0}", input);
      Console.WriteLine("Replacement String: {0}", result);

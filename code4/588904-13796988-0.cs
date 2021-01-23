    string pattern = @"(?<Match>(?:""[^""]*""|[^,])*)(?:,(?<Match>(?:""[^""]*""|[^,])*))*";
		
    string[] testCases = new[]{
	  @"",
	  @"A,B,C",
	  @"A,B"",C",
	  @"ABC"",""Text with,",
	  @""",ABC"",""next_field""",
	  @""""",ABC"",""next_field"""
    };
		
    foreach(string testCase in testCases){
	  var match = System.Text.RegularExpressions.Regex.Match(testCase, pattern);
      string[] matchedValues = match.Groups["Match"].Captures
        .Cast<System.Text.RegularExpressions.Capture>()
        .Select(c => c.Value)
        .ToArray();
    }

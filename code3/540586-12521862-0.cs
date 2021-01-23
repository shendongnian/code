    // First we see the input string.
    string input = "/content/alternate-1.aspx";
    // Here we call Regex.Match.
    Match match = Regex.Match(input, @"[ ]is[A-z0-9]*",	    RegexOptions.IgnoreCase);
    // Here we check the Match instance.
    if (match.Success)
    {
        // Finally, we get the Group value and display it.
	    string key = match.Groups[1].Value;
	    Console.WriteLine(key);
    }

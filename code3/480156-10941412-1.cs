    Match match = 
        Regex.Match(
            ConnectionAPI.responseFromServer, 
            "\"\\**?ouser\\**?":\\s*\"([^\"]*)\",",
            RegexOptions.IgnoreCase);
    String output = String.Empty;
	// Here we check the Match instance.
    if (match.Success)
    {
	    // Finally, we get the Group value and display it.
	    output = match.Groups[1].Value;
	    Console.WriteLine(output);
    }

    Regex regex = new Regex(@"(?!\s*$)(.*?)(?:\((Ticker:[^;]+)?[^)]*(?:(?:SIC|NAICS|Duns):[^)]*)+\)|$)");
    Match match = regex.Match("Berkshire Hathaway Inc (NAICS: 524126, 511130, 335212, 445292, 511110, 442210; Duns: 00-102-4314) Walt Disney Co (Ticker: DIS; NAICS: 713110, 512110, 711211, 515120; Duns: 00-690-4700)");	
    while (match.Success) {
    	if (match.Groups[1].Success)
    	{
    		Console.WriteLine(match.Groups[1].Value);
    	}
    	else
    	{
    		Console.WriteLine(match.Groups[0].Value);
    	}
    	match = match.NextMatch();
    }
 

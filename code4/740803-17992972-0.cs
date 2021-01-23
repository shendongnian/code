    var match = System.Text.RegularExpressions.Regex.Match(str, "OVDPCT (?<Number>\d+)P", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    
    if(match.Success)
    {
    	var number = match.Groups["Number"].Value;
    }

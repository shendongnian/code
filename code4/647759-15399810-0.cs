    Match m = distRex.Match(testInput);
    if(m.Success)
    {
        string keywords = distRex.Replace(testInput, string.Empty);
        string distanceUnits = m.Groups["unit"].Value;
        int distance = Int32.Parse(m.Groups["dist"].Value);    
    }

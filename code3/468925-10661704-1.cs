    string longString = "ABCDEFGHIJK";
    int groupingLength = 3;
    
    var stringLength = longString.Length;
    var startingLength = Math.Min(longString.Length, groupingLength);
    var startingString = longString.Substring(0, startingLength);
    var sb = new StringBuilder(startingString);
    if (stringLength > groupingLength)
    {
    	for(int i = groupingLength; i < stringLength; i = i + groupingLength)
    	{
    		var subStringLength = Math.Min(stringLength - i, groupingLength);
    		var groupedString = longString.Substring(i, subStringLength);
    		sb.Append(", ").Append(groupedString);
    	}
    }
    var finalString = sb.ToString();

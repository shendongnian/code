    while (reader.Read())
    {
    	Decimal tryParseResultDec;
    	object value = reader.GetValue(0);
    	if !(Decimal.TryParse(value, out tryParseResultDec))
    	{
    		throw new ArgumentException(string.Format("Unable to parse '{0}'.", value));   
    	}
    
    }

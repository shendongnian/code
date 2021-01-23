    public DateTime ReadDateFromExcel(string dateFromXL)
    {
    	Regex dateRegex = new Regex("^([1-9]|0[1-9]|1[0-2])[- / .]([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])[- / .](1[9][0-9][0-9]|2[0][0-9][0-9])$");
    	DateTime dtParam = new DateTime();            
    	if (!DateTime.TryParse(dateFromXL, out dtParam))
    	{
    		double oaDate = 0;
    		if (Double.TryParse(dateFromXL, out oaDate))
    		{
    			dateFromXL = DateTime.FromOADate(oaDate).ToString("MM/dd/yyyy");
    			if (!dateRegex.IsMatch(dateFromXL))
    			{
    				Console.Writeline("Date not in correct format");
    			}
    			else
    			{
    				dtParam = readDateFromExcel(dateFromXL);
    			}
    		}
    		else
    		{
    			Console.Writeline("Date not in correct format");
    		}
    	}
    	else
    	{
    		Console.Writeline("Date is in correct format");
    	}
    	return dtParam;
    }

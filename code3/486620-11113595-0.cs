    protected DateTime ReturnPropertDateTime(object val)
    {
            DateTime dt = null;
             string dateTimeValue = Convert.ToString(val);
    	DateTime dateTime2;
    	if (DateTime.TryParse(dateTimeValue.ToString("ddMMyyyy"), out dateTime2))
    	{
    	    dt = dateTime2;    	
          }
    	else
    	{
    	     dt = // Just Assign Default date time value you want.
    	}
    
    return dt;
    
    }

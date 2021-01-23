    public override bool IsValid(object value)
    {
    	var dt = value as DateTime?;
    	
    	return dt == null || dt.Value.Date > DateTime.Today.AddDays(1).AddSeconds(-1);
    }

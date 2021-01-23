	public static decimal ToDecimal(this string value){
		try
		{
			return Decimal.Parse(value);
		}   
		catch (Exception)
		{
			//	catch FormatException, NullException
			return 0;
		}
	}
	//	use
	PropertyA = row["ValueA"].ToString().ToDecimal();
	PropertyB = row["ValueB"].ToString().ToDecimal();
	PropertyC = row["ValueC"].ToString().ToDecimal();

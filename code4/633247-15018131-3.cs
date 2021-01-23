	DateTime DOB;
	IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
	String datetime = txtDOB.Text.Trim();
	DateTime.TryParse(datetime, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out DOB);
	if (DOB != DateTime.MinValue)
	{
	    objEmp.DOB = null; 
	}
	else
	{
	    objEmp.DOB = date;
	}

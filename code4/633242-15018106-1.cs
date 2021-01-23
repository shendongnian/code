    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
            String datetime = txtDOB.Text.Trim();
    
    if(DateTime.TryParse(datetime, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out date))
    {
      objEmp.DOB = date;
    }
    

    DateTime startDate, endDate;
    if ((!DateTime.TryParseExact(txtComStartDate.Text, "dd/MM/yy", provider, DateTimeStyles.AssumeLocal, out startDate) 
            || DateTime.Parse(itemDate, provider, DateTimeStyles.AssumeLocal) >= startDate) && 
        (!DateTime.TryParseExact(txtComEndDate.Text, "dd/MM/yy", provider, DateTimeStyles.AssumeLocal, out endDate)
            || DateTime.Parse(itemDate, provider, DateTimeStyles.AssumeLocal) <= endDate))
    {
        // Do something here.
    }

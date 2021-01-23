    DateTime startDate, endDate;
    if ((!DateTime.TryParseExact(txtComStartDate.Text, "dd/MM/yy", provider, DateTimeStyles.None, out startDate) 
            || DateTime.Parse(itemDate) >= startDate) && 
        (!DateTime.TryParseExact(txtComEndDate.Text, "dd/MM/yy", provider, DateTimeStyles.None, out endDate)
            || DateTime.Parse(itemDate) <= endDate))
    {
        // Do something here.
    }

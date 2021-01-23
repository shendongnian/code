    DateTime startDate, endDate;
    if ((!DateTime.TryParseExact(txtComStartDate.Text, "dd/MM/yy", provider, out startDate) 
            || DateTime.Parse(itemDate) >= startDate) && 
        (!DateTime.TryParseExact(txtComEndDate.Text, "dd/MM/yy", provider, out endDate)
            || DateTime.Parse(itemDate) <= endDate))
    {
        // Do something here.
    }

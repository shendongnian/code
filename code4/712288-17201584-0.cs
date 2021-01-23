    DateTime startDate;
    if (DateTime.TryParseExact(txtStartDate.Text, "MM/dd/yyyy", 
            CultureInfo.CurrentCulture, DateTimeStyles.None, out startDate))
    {
        Session["StartDate"] = startDate;
    }
    DateTime endDate;
    if (DateTime.TryParseExact(txtEndDate.Text, "MM/dd/yyyy", 
            CultureInfo.CurrentCulture, DateTimeStyles.None, out endDate))
    {
        Session["EndDate"] = endDate;
    }

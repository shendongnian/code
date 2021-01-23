    IList<DateTime> exclusionDates = new List<DateTime>();
    
    while (drDates.read())
    {
        exclusionDates.Add(Convert.ToDateTime(drDates["reportDate"].ToString()));
    }
    
    for (DateTime dateTime = startDate; dateTime < endDate; dateTime += TimeSpan.FromDays(interval))
    {
        if (!exclusionDates.Contains(dateTime))
        {
            this.Label1.Text += dateTime.ToString() + "</br>";
        }
    }

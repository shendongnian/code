    DateTime lastDate = DateTime.ParseExact("01/12/12", "dd/MM/yy", System.Globalization.CultureInfo.InvariantCulture);
    
    List<DateTime> result = new List<DateTime>();
    //iterate until the difference is two months 
    while (new DateTime((DateTime.Today - lastDate).Ticks).Month >= 2)
    {
        result.Add(lastDate);
        lastDate = lastDate.AddMonths(1);
    }
    //result: 12/1/2012
    //         1/1/2013
    //         2/1/2013
    //         3/1/2013

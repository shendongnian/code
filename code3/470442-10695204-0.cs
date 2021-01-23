    query = service.GetData();
        List<String> results = new List<String>();
        foreach (var item in query)
        {
            var unformattedDate = item.InDate;
            var formattedDate = DateTime.ParseExact(unformattedDate,
                                        "yyyyMMddHHmmssfff",
                                        System.Globalization.CultureInfo.InvariantCulture)
            results.Add(formattedDate);                              
        }
        return results;

    var dict = dt.AsEnumerable()
                 .ToDictionary(
                     row => row[0].ToString(),
                     row => {
                         return new MarketDataBEO()
                         {
                             MarketID = row[0].ToString(),
                             MarketHeirarchyID = row[1].ToString()
                             // Other class members here
                             // MarketName = row[2].ToString()
                             // TotalMarketSizeCYM1GI = row[3].ToString()
                         }
                 );
    foreach (var m in dict.Values)
    {
        if (!string.IsNullOrEmpty(m.MarketHeirarchyID))
            dict[m.MarketHeirarchyID].childDetails.Add(dict[m.MarketID]);
    }
    var result = dict.Values.ToList();

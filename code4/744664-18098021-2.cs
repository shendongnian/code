    var marketDataBEO = new MarketDataBEO() { MarketID = "0" };
    var dictionary = new Dictionary<string, MarketDataBEO>();
    dt.Rows.Cast<DataRow>()
        .ToList().ForEach(dr =>
        {
            var m = new MarketDataBEO()
                {
                    MarketID = dr["MarketID"].ToString(),
                    MarketHeirarchyID = dr["MarketHeirarchyID"].ToString()
                };
            dictionary.Add(m.MarketID, m);
        });
    dictionary.ToList().ForEach(kvp =>
    {
        if (kvp.Value.MarketHeirarchyID == "")
        {
            marketDataBEO.childDetails.Add(kvp.Value);
        }
        else
        {
            dictionary[kvp.Value.MarketHeirarchyID].childDetails.Add(kvp.Value);
        }
    });

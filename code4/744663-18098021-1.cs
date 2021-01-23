    var marketDataBEO = new MarketDataBEO() { MarketID = "0" };
    var dictionary = new Dictionary<string, MarketDataBEO>();
    dt.Rows
        .Cast<DataRow>()
        .OrderBy(dr => Convert.ToInt32(dr["MarketID"].ToString()))
        .ToList().ForEach(dr =>
        {
            var m = new MarketDataBEO()
                {
                    MarketID = dr["MarketID"].ToString(),
                    MarketHeirarchyID = dr["MarketHeirarchyID"].ToString()
                };
            if (dr["MarketHeirarchyID"].ToString() == "")
            {
                marketDataBEO.childDetails.Add(m);
            }
            else
            {
                dictionary[dr["MarketHeirarchyID"].ToString()].childDetails.Add(m);
            }
            dictionary.Add(m.MarketID, m);
        });

    var allItems = from c in PriceListPolicies_TBLs
                   select c;
    foreach (var c in allItems)
    {
        if (c.CountryCode == "VNALL")
        {
            c.CountryCode = "VN";
        }
        else if (c.CountryCode == "THALL")
        {
            c.CountryCode = "TH";
        }
    }

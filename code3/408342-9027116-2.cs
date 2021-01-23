    var uniqueCountryCustomer =
             tblData.AsEnumerable()
            .GroupBy(row => new
            {
                Country = (string)row["COUNTRYCODE"],
                Customer = (string)row["CUSTOMERNAME"]
            }).Select(grp => grp);

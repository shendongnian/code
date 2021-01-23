    var uniqueCountryCustomer = 
                from d in tblCustomer.AsEnumerable()
                group d by new{
                    Country=(string)d["COUNTRYCODE"],
                    Customer=(string)d["CUSTOMERNAME"]
                }
    // display result
    var summary = from cc in uniqueCountryCustomer
                  select string.Format("Country:{0} Customer:{1} Count:{2}", 
                  cc.Key.Country, 
                  cc.Key.Customer, 
                  cc.Count());
    MessageBox.Show(string.Join(Environment.NewLine,summary));

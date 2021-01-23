    var uniqueCountryCustomer = 
                from row in tblCustomer.AsEnumerable()
                group row by new{
                    Country=(string)row["COUNTRYCODE"],
                    Customer=(string)row["CUSTOMERNAME"]
                };
    // display result
    var summary = from cc in uniqueCountryCustomer
                  select string.Format("Country:{0} Customer:{1} Count:{2}", 
                  cc.Key.Country, 
                  cc.Key.Customer, 
                  cc.Count());
    MessageBox.Show(string.Join(Environment.NewLine,summary));

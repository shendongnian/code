    var uniqueCountryCustomer = 
                from d in tblCustomer.AsEnumerable()
                group d by new{
                    Country=(string)d["COUNTRYCODE"],
                    Customer=(string)d["CUSTOMERNAME"]
                } into Group
                select Group;
    var summary = from cc in uniqueCountryCustomer
                 select string.Format("Country:{0} Customer:{1}", cc.Key.Country, cc.Key.Customer);
    var message=string.Join(Environment.NewLine,summary);
    MessageBox.Show(message);

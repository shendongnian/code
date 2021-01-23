     List<Country> countries = new List<Country> {
                                      new Country(1,"UK"), 
                                      new Country(2,"Turkey"), 
                                      new Country(8,"Turkey"),
                                      new Country(5,"Turkey"), 
                                      new Country(2,"Turkey"),
                                      new Country(3,"USA") ,
                                      new Country(3,"USA")};  //.Distinct(new CountryEqualityComparer()).ToList();
            var Data = (from i in countries
                    select new ComboItem { ValueMember = i.ID, DisplayMember = i.Name }).Distinct(new ComboItemEqualityComparer()).ToList();
            cbName.DataSource = Data;
            cbName.DisplayMember = "DisplayMember";
            cbName.ValueMember = "ValueMember";

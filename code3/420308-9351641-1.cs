    var lst = new List<Country>();
    lst.Add(new Country(){IdCountry = 1, Code = "ukr", Title = "Ukraine"});
    lst.Add(new Country() { IdCountry = 2, Code = "rus", Title = "Russia" });
    lst.Add(new Country() { IdCountry = 3, Code = "fr", Title = "France" });
    string tst = lst.ContriesToString();

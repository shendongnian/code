    {
           var countries= _transactionService.GetAllCountries();
           var distinctcountries = countries.GroupBy(c=> c.CountryName); 
           _UIDDListCountries.DataSource = distinctcountries.Select(g => new { CountryID = g.First().CountryID, CountryName = g.First().CountryName ,Text = String.Concat(g.First().CountryName, "--", g.First().Year) }) ;
           _UIDDListCountries.DataTextField = "Text";
           _UIDDListCountries.DataValueField = "CountryName";
    }

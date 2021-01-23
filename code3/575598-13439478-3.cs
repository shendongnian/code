    BindingList<City> cities = new BindingList<City>()
    {
        new City() { Name = "Carros", Country = "France", CountryCode = "FRA" },
        new City() { Name = "Barcelona", Country = "Spain", State = "Catalonia" }
    };
    
    dataGridView.DataSource = cities;

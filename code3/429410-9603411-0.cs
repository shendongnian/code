    var inSelectedCities = PredicateBuilder.True<Hotel>();
    foreach(var city in SelectedCity)
    {
        string temp = city;
        inSelectedCities = inSelectedCities.Or(h => h.City.UniqueId == temp);
    }
    var inSelectedCategories = PredicateBuilder.True<Hotel>();
    foreach(var category in SelectedCategories)
    {
        string temp = category;
        inSelectedCategories = inSelectedCategories.Or(h => h.Category.UniqueId == temp)
    }
    var hotels = Hotels
                    .Where(inSelectedCities.Or(inSelectedCategories))
                    .ToList();

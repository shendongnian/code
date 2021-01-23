    //Add a constructor
    public CityViewModel()
    {
        //Populate the variable
        CityDetails = Enumerable.Repeat(new CityDetail(), 10).ToList();
    }

    //Add a constructor
    public CityViewModel()
    {
        //Populate the variable
        CityDetails = Enumerable.Range(1,10).Select(x => new CityDetail()).ToList();
    }

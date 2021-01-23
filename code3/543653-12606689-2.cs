    // Code inside your controller should be like this
    ViewModel myModel = new ViewModel();
    List<object> countries = new List<object>();
    countries.Add(new { Name = "United States", Abbr = "US" , Currency = "$"});
    countries.Add(new { Name = "Canada", Abbr = "CA", Currency = "$" });
    myModel.countries = countries;
    
    return View("yourView", myModel);

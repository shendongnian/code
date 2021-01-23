    // Code inside your controller should be like this
    ViewModel myModel = new ViewModel();
    List<object> countries = new List<object>();
    countries.Add(new { Name = "United States", Abbr = "US" , Currency = "$"});
    countries.Add(new { Name = "Canada", Abbr = "CA", Currency = "$" });
    myModel.countries = countries;
    
    return View("yourView", myModel); // you can write just return View(myModel); if your view's name is the same as your action 

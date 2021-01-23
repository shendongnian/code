    [HttpPost]
    public ActionResult Index(String carMake, String carModel)
    {
       //Redirect to SearchResults. You can do this from client as well.
       return RedirectToAction("SearchResult",  
                    new { make = carMake, model = carModel });
    }
    //Add your filter and order code here
    public ActionResult SearchResult(String make, String model)
    {
         var cars = from d in db.Cars
                    select d;
        if (!String.IsNullOrEmpty(make))
        {
            if (!carMake.Equals("All Makes"))
            {
                cars = cars.Where(x => x.Make == make);
            }
        }
        if (!String.IsNullOrEmpty(model))
        {
            if (!carModel.Equals("All Models"))
            {
                cars = cars.Where(x => x.Model == model);
            }
        }
        cars = cars.OrderBy(x => x.Make);
        return View(cars);
    }

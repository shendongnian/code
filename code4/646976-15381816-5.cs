    //this is get
    public ActionResult  ShowLocations()
    {
        var model = new PlacesAndEventsViewModel();
    
        model.CityID = null; //or any default value
        model.LocationOption = "places"; //or any default value
        model.Places = new List<Place>(); //or GetAllPlacesFromDB();
        //You can do the same for events but I think you need one at a time
    
        return View("ViewPlaces", model);
    }
    [HttpPost]
    public ActionResult  ShowLocations(PlacesAndEventsViewModel model)
    {
        if(model.LocationOption = "places")
        {
            model.Places = GetAllPlacesByCity(model.CityID);
            return View("ViewPlaces", model);   //All these could be partial view
        }
        else if(model.LocationOption = "cities")
        {
            model.Events = GetAllEventsByCity(model.CityID);
            return View("ViewEvents", model);  //All these could be partial view
        }
        else
        {
            return View("ViewPlaces", model);  //All these could be partial view
        }
    }   

    //Get
    public ActionResult NewBooking()
    {
        var db = new VirtualTicketsDBEntities2();
        var items = db.Attractions.ToList();
        var attractionIdDefault = 0;// default value if you have one
        var vm = new AttractionViewModel {
            AttractionId = attractionIdDefault,// set this if you have a default value
            Attractions = new SelectList(items, "A_ID", "Name", attractionIdDefault)
        }    
        return View(vm);
    }

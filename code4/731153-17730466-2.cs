    //Get
    public ActionResult NewBooking()
    {
        var db = new VirtualTicketsDBEntities2();
        var items = db.Attractions.ToList();
        var vm = new AttractionViewModel {
            AttractionId = // set this if you have a default value
            Attractions = new SelectList(items, "A_ID", "Name", attractionId)
        }    
        return View(vm);
    }

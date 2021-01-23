    public ActionResult SearchResult(String sortOrder, String carMake, String carModel)
        {
    
            var cars = from d in db.Cars
                        select d;
            ManageCarSearch objsearch = new ManageCarSearch();
           ////your Logic
    
            return View(objsearch);
    }

    [HttpPost]
    public ActionResult Comparison(int id)
    {
       ViewBag.make = db.Car.FirstOrDefault(x => x.ID == id).Make;
       return View();
    }

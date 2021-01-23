    public ActionResult MyAction(){
    var store = db.Stores.Where(x => x.ID == objId).Select(x => new StoreModel(){
        Name = x.Name,
        ID = x.ID,
        lastShift = db.Shifts.FirstOrDefault(y => y.SiteID == x.ID).OrderByDescending(shift => shift.Date);
    }).FirstOrDefault();
    
    return View(store);
    }

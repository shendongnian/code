       public ActionResult Create()
        {
            ViewBag.CostCentre_ID = new SelectList(db.CostCentres, "ID", "Name");
            ViewBag.Location_ID = new SelectList(db.Locations, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UCMUsers, "User_ID", "EmployeeNo");
            return View();
        } 

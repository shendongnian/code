     [HttpPost]
     public ActionResult Create(SomeObject object)
     {
       if (ModelState.IsValid)
       {
          //insert code here
       }
       return View();
     }

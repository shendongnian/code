    [HttpPost]
    public ActionResult Create(CreateItemVM model)
    {
      if(ModelState.IsValid)
      {
         Item domainObject=new Item();
         domainObject.ManufacturerID =model.SelectedManufactureID ;
         //set other relevant properties also
          db.Items.Add(ıtem);
          db.SaveChanges();
          return RedirectToAction("Index");
      } 
      //to do :reload the dropdown before returning to the view
      return View(model);   
    }

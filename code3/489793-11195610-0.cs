    [HttpPost] 
        public ActionResult Edit(ClientContactViewModel model) 
        { 
            if (ModelState.IsValid) 
            { 
    
               var client = db.Client.Where(c => c.Id = model.ClientPersonId);
               client.FirstName = model.FirstName;
    
               ...etc through all your properties and other models...
    
    
                db.Entry(model).State = EntityState.Modified; 
                db.SaveChanges(); 
                return RedirectToAction("Index"); 
            } 
            return View(model); 
        } 

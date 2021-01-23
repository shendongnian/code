    public ActionResult Edit(OBJECT_PRODUCER _objProd)
    {
        if (ModelState.IsValid)
        {
            //this line might not be quite right, but basically 
            //get the entity from dbContext based on the id of the submitted object
            OBJECT_PRODUCER originalFromDbContext = m_Db.GetById(_objProd.Id);
        
            //set the values for the Entity retrieved from m_Db to the new values
            //submitted by the user
            m_Db.Entry(originalFromDbContext).CurrentValues.SetValues(_objProd);
            m_Db.SaveChanges(); //save changes
            return RedirectToAction("SearchIndex");
        }
        return View(_objProd);
    }

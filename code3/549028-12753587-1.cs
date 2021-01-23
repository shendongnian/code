    [HttpPost]
    public ActionResult Edit(VersionViewModel model)
    {
      if(ModelState.IsValid)
      {
         //validation is ok. Let's save
        var domainModel=new Version();
        domainModel.VERSION_ID=model.VersionID ;
        domainModel.Name=model.Name;
       
        //Let's save and REdirect 
        yourRepositary.SaveVersion(domainModel);
        return RedirectToAction("Saved",new { id=model.ID});     
      }
      return View(model);
    }

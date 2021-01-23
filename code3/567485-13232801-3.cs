    [HttpPost]
    public ActionResult Create(ChamodoVM model)
    {
      if(ModelState.IsValid)
      {
        var domainModel=new Chamodo();
        domainModel.Name=model.ChamodoName;
        domainModel.Interaco=new Interaco();
        domainModel.Interaco.Name=model.InteracoName;
    
        yourRepositary.SaveClient(domainModel);  
        //If saved successfully, Redirect to another view (PRG pattern)
        return RedirectToAction("ChamodoSaved");
      }
      return View(model);    
    }

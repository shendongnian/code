     [HttpPost]
    public ActionResult AddTag(MyModel model)
    {
       if(ModelState.IsValid)
       {
          //Check for model.Tags collection and Each items IsSelected property value.
          //Save and Redirect(PRG pattern)
       }
       return View(model);
    }

    public ActionResult SomeAction()
    {
         var model = new BaseModel();
    
         if (TryUpdateModel(model, null, null, new[] { "RequiredProperty" })) // fourth parameter is an array of properties (by name) that are excluded
         {
              // updated and validated correctly!
              return View(model);
         }
         // failed validation
         return View(model);
    }

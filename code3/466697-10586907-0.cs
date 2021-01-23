    public ActionResult SomeAction()
    {
      if (model.CustomerOrderTrackings == null 
          || model.CustomerOrderTrackings.Count > 0) 
      {
        // Do Something with model
      }
 
      this.View(model)
    }

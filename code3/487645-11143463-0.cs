    public ContentResult TestAction()
    {
       var model = new MyModel();
    
       if(TryUpdateModel(model, new QueryStringValueProvider(ControllerContext)))
       {
          return Content("success");
       }
    
       return Content("failed");
    }

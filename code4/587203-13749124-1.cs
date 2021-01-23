    public ActionResult SomeActionMethod()
    {
         MyModel model = ...
 
         //manually invoke the model binding process considering only query string data
         //The custom model binder will be used only if it was globally registered
         //in the binders dictionary or set in an attribute of the model class
         TryUpdateModel(model, new QueryStringValueProvider())
         ...
    }

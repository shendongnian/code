    public ActionResult SomeActionMethod(FormCollection formCollection)
    {
      foreach (var key in formCollection.AllKeys)
      {
        var value = formCollection[key];
      }
    // or 
    var color=formCollection["color"];
    }

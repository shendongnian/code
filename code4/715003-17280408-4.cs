    public ActionResult Index(int id)
    {
      //Lambda (just for an example, there is nothing wrong with LINQ expressions)
      var client = db.Clients
        .FirstOrDefault(c => c.ClientID == id);
      if (client != null)
      {
        var model = new IndexViewModel();
        model.ClientID = id;
        model.Clients = // some value I don't understand
        // My preference/opinion (programming religion) is to prefix with this
        // so others know if the method is *this* class, *base* class etc
        return this.View(model); 
      }
    
      return HttpNotFound();
    }

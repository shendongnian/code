    public ActionResult CostOptions()
    {
         // creates instance of the proxy
         var oi = db.OrderItems.Create();
         if (TryUpdateModel(oi))
         {
              // new entity has to be added before retrieving lazy loaded prop
              db.OrderItems.Add(oi);
              // lazy loaded property
              var frame = oi.Frame;
         }
    }

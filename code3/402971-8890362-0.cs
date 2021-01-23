    public ActionResult CostOptions(int id)
    {
         var oi = db.OrderItems.Find(id);
         if (TryUpdateModel(oi))
         {
              // lazy loaded property
              var frame = oi.Frame;
         }
    }

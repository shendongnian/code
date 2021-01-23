    public ActionResult Orders(int id = -1)
    {
      return id == -1 ? this.OrdersSummary() : this.OrdersDetail(id);
    }
    private ActionResult OrdersSummary()
    {
      var model = new SummaryModel();
      // fill in model;
      return this.View("OrdersSummary", model);
    }
    private ActionResult OrdersDetail(int id) 
    {
      var model = new DetailModel();
      // fill in model;
      return this.View("OrderDetail", model);
    }    

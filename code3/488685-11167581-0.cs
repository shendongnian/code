    [HttpGet]
    public ActionResult Edit(int id)
    {
        // (you can probably rewrite this using a lambda
        var orderWithLines = from o in db.Orders.Include("OrderLines")
                             select o;
    
        // Use ViewData rather than passing in the object in the View() method.
        ViewData.Model = orderWithLines.FirstOrDefault(x => x.ID = id);
        return View();
    }
    
    [HttpPost]
    public ActionResult Edit(OrderTracker.Models.Order model)
    {
        if (ModelState.IsValid)
        {
            // call the service layer / repository / db to persist the object graph
            _service.Save(model); // this assumes your view models are the same as your domain
        }
    }

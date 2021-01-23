    [HttpPost]
    public ActionResult(MyViewModel model)
    {
      if (ModelState.IsValid)
      {
        // ID was passed, re-fetch the customer based on selected id
        Customer customer = Customers.GetById(model.CustomerId)
        /* ... */
      }
      /* ... */
      return View();
    }

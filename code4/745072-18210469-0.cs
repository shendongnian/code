    public ActionResult ConfirmDelete(IDynamicTable obj)
    {
       // ...
       if (obj is Company)
       {
          // Delete in company table
          return View("Company");
       }
       if (obj is User)
       {
          // Delete in user table
          return View("User");
       }
       // ... 
    }

     public ActionResult CustomersDetails(long[] SelectRight)
     {
          if (SelectRight == null)
          {
               ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
               return RedirectToAction("Index");
          }
          else
          {
               '...

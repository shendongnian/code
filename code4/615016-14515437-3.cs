      public ActionResult Index(int? page)
        {
          ...
          if (Request.IsAjaxRequest())
            {
              return PartialView("_partialviewname", db.model)  
             }
          return View(db.model)
        }

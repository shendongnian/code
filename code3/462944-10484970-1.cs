     public ActionResult Index()
     {
        var objProduct = new ProductViewModel();
        objProduct.Items = new[]
        {
              new SelectListItem { Value = "1", Text = "Domain 1" },
              new SelectListItem { Value = "3", Text = "Domain 2" },
              new SelectListItem { Value = "3", Text = "Domain 3" }
        };
        // can replace the above line with loading data from Data access layer.
        return View(objProduct);
    }

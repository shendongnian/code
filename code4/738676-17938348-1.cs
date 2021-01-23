    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult Index()
    {
        var model = new CrossFieldValidation {
            Items = new [] {             
               new SelectListItem{ Text = "Amount" , Value = "Amount"},
               new SelectListItem{Text= "Pound", Value ="Pound"},
               new SelectListItem {Text ="Percent", Value ="Percent"}            
            }
        };     
        
        return View(model);
    }

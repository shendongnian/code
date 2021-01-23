    public ActionResult Index()
    {
         ViewBag.Country = new []{ 
                               new SelectListItem() { Text = "Venezuela" , Value = "1" },
                               new SelectListItem () { Text = "United States" , Value = "2" }};
         return View();
    }

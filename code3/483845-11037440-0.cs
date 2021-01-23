    public ActionResult HomePage()
    {
        IEnumerable<dale_harrison.Models.News> model = new List<dale_harrison.Models.News>();  
        // prepare your model (populate it with proper data)
        return View(model);
    } 

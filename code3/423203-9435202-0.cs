    public ActionResult Index(int? id, string search)
    {
        var model = new MyViewModel
        {
            DetailsPartial = (id != null) ? "_details" : "_grid"
        }; 
        return View(model);
    }

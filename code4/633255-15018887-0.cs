    [HttpPost]
    public ActionResult Index(YourModel model) {
        if (ModelState.IsValid) {
           //do something
        }
        return View();
    }

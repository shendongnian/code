    [HttpGet]
    [Authorize(Roles = "Admin")]
    public ActionResult ProjectAdd()
    {
        // Get all categories and pass it into the View
        ViewBag.Categories = db.ListAllCategories();
        return View();
    }

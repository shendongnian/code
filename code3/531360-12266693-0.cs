    public ActionResult ViewCategory(int categoryId, string view)
    {
        ViewBag.ViewType = view;
        return View();
    }

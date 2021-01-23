    public ActionResult Browse(string title)
    {
        var spices = spiceDB.Products.Where(p => p.Title == title);
        return View(spices);
    }

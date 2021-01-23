    public ActionResult _Quickblah()
    {
        ViewBag.CategoryID = new SelectList(Repository.Categorys, "CategoryID", "Title");
        Blah blah = new Blah () { CreatedDate = DateTime.Now };
        return PartialView(blah);
    }

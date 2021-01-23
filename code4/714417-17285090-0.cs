    //
    // GET: /Store/Details/4
    public ActionResult Details(int? id)
    {
        var album = db.Albums.Find(id);
        return ViewIfNotNull(album);
    }
    
    // boxing
    private ActionResult ViewIfNotNull(object model)
    {
        if (album == null) return RedirectToAction("Index");
        else return View(album);
    }
    
    // OR generic
    private ActionResult ViewIfNotNull<T>(T model)
    {
        if (album == null) return RedirectToAction("Index");
        else return View(album);
    }

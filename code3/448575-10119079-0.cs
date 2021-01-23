    // don't forget to use the System.Linq namespace
    public ActionResult Details(int id)
    {
        var show = db.Shows.Single(s.Id == id);
    }

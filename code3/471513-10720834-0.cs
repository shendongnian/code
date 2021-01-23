    public ActionResult Index() {
        var album = new AlbumModel();
        var otherModel = new AnotherModel();
        var model = new CompositeModel();
        return View(model)
    }

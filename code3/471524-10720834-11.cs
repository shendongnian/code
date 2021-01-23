    public ActionResult Index() {
        var compositeModel = new CompositeModel();
        compositeModel.Album = new AlbumModel();
        compositeModel.OtherModel = new AnotherModel();
        compositeModel.EvenMore = new Other();        
        return View(compositeModel)
    }

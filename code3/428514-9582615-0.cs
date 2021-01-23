    public ActionResult Collection(int id)
    {
        var collectionModel = ds.GetCollection(id);
        return View("/Brand2/Collection", collectionModel);
    }

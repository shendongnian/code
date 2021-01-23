    public ActionResult Details(int id)
    {
        var model = repository.Get(id);
        return PartialView(model);
    }

    public ActionResult Details(int id1 = 0, int id2 = 0)
    {
        string test = "...";
        var viewModel = db.Database.SqlQuery<ProdList>(test).ToList();
        if (!viewModel.Any())
            return HttpNotFound();
        return View(viewModel);          
    }

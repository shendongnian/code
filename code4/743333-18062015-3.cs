    public ActionResult Details(int id1 = 0, int id2 = 0)
    {
        string test = "...";
        ProdList prodList = db.Database.SqlQuery<ProdList>(test).FirstOrDefault();
        if (prodList == null)
            return HttpNotFound();
        return View(prodList);          
    }

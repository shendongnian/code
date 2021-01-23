    var viewModel = db.Database.SqlQuery<ProdList>(test).FirstOrDefault();
    if (viewModel == null)
    {
        return HttpNotFound();
    }
    return View(viewModel)); 

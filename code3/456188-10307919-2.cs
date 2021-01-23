    public ActionResult Organic(int id = 0)//Store/Organic
    {
        ProductManager mgr = new ProductManager();
        var list = mgr.IsOrganic(id);
        return View(list);
    }

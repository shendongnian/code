    public ActionResult Organic(
          [System.ComponentModel.DefaultValue(0)] int id) //Store/Organic
    {
        ProductManager mgr = new ProductManager();
        var list = mgr.IsOrganic(id);
        return View(list);
    }

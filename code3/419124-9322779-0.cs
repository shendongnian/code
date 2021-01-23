    public ActionResult List()
    {
       dynamic returnModel = new ExpandoObject();
       returnModel.Data = repos.GetData();
       return View(returnModel);
    }

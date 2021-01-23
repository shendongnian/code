    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult Search(string value)
    {
        IPresenter presenter = new Presenter();
        List<Item> items = presenter.GetList(value);
        if (items.Count > 1)
        {
            return base.View("List", items);
        }  
        else
        {
            //your logic and model from Detail Action f.e:
            var model = repository.GetDetailModel(items.First().Id);
		
            return View("Detail", model);
        }
    }

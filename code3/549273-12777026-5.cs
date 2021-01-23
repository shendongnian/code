    public ActionResult Index()
    {
        cHomeModel HomeModel = new cHomeModel();
        HomeModel.nvc.Add("class", "chzn-select");
        HomeModel.nvc.Add("data-placeholder", "Choose a customer");
        HomeModel.nvc.Add("style", "width:350px;");
        HomeModel.nvc.Add("tabindex", "1");
        HomeModel.nvc.Add("multiple", "multiple");
        HomeModel.nvc.Add("id", "lol");
        HomeModel.ls = System.Linq.Enumerable.Range(0, 9)
                .Select(x => new cOption() { text = x.ToString(), value = x.ToString() })
                .ToList();
 
        // or otherwise: 
        HomeModel.ls = (
                     from i in System.Linq.Enumerable.Range(0, 9)
                     select new cOption() { text = i.ToString(), value = i.ToString() }
        ).ToList();
        return View(HomeModel);
    }

    public ActionResult Index()
    {
        MyModel model = new MyModel();
        model.Docs = db.IPACS_Master_List;
        model.Departments = db.IPACS_Master_List
           .Where(x => x.department != null)
           .Select(s => s.department)
           .Distinct()
           .Select(s => new SelectListItem
               {
                   Text = s.Name, //whatever the name property is
                   Value = s.Id //whatever the Id property is
               })
           .ToList();
            return View(model);
    }

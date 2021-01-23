    public ActionResult Index()
    {
        using (PropertyContext db = new PropertyContext())
        {
            var query = 
                from prop in db.Property.Find(94284)
                join type in db.Type on prop.TypeId equals type.TypeId
                select new MyViewModel
                {
                    RecId = prop.Rec_Id,
                    Name = prop.Name,
                    TypeName = type.TypeName
                };
            var viewModel = query.FirstOrDefault();
            return View(viewMode);
        }
    }

    public ActionResult Create()
    {
        IList<Category> categories;
        using (var session = NHibernateHelper.OpenSession())
        using (var tx = session.BeginTransaction())
        {
            categories = session.CreateCriteria(typeof(Category)).List<Category>();
            tx.Commit();
        }
        IEnumerable<SelectListItem> categoriesList = categories.Select(category => new SelectListItem() { Text = category.Name, Value = category.Id.ToString() });
        ViewBag.Categories = categoriesList;
        // or fetch from DB or whatever
        var news = new News();
        return View(news);
    }

    public int? SelectedId { get; set; }
    @Html.DropDownListFor(m => m.SelectedId, Model.Categories, "--Select One--")
                
    [HttpPost]
    public ActionResult Create(NewsViewModel newsViewModel)
    {
        if(ModelState.isValid())
        {
        try
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    newsViewModel.News.Category.Id = newsViewModel.SelectedId.Value;
                    session.Save(newsViewModel.News); 
                    tx.Commit();
                }
            }
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
        }
    }

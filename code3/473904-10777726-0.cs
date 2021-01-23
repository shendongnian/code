    public ActionResult Index()
    {
        IEnumerable<MyTable> model;
    
        using (var context = new MyEntities())
        {
            model = (from mt in context.MyTable
                    select mt).ToList();
        }
        return View(model);
    }

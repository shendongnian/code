    public ActionResult Index()
    {
        IEnumerable<MyTable> model;
    
        using (var context = new MyEntities())
        {
            model = (from mt in context.MyTable
                    select mt).ToArray();
        }
        return View(model);
    }

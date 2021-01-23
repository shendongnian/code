    public ActionResult Index(Guid id)
    {
        MyClass model;
        // call the DAL
        var entity = DataAccess.GetById(id);
        // call the model
        if(entity != null)
        {
            model = new MyClass(entity);
        }
        else
        {
            model = null;
        }
        Return View(model);
    }

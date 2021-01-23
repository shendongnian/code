    public ActionResult Create<T>(MyClassView content)
    {            
        if (ModelState.IsValid)            
        {
            var entity = content.GetEntity();
            GetDbSet(db, entity).AddOrUpdate(entity);
            db.SaveChanges();
            return Content("Ok");
        }
        return PartialView(content);
    }
    DbSet<T> GetDbSet<T>(DbContext db, T entity) where T : class
    {
        return db.Set<T>();
    }

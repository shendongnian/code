    public static class ControllerExtensions
    {
        public static ActionResult StandardEdit<TEntity>(
            this Controller controller, 
            DbContext db, 
            long id)
            where TEntity : class
        {
            TEntity entity = db.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return controller.HttpNotFound();
            }
            return controller.View(entity);
        }
    }
    public ActionResult Edit(long id = 0)
    {
        return this.StandardEdit<Client>(db, id);
    }

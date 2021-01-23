    public class StandardController : Controller
    {
        public ActionResult Edit<TEntity>(long id = 0)
            where TEntity : class
        {
            TEntity entity = db.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }
    }

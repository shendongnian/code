    public ActionResult DeleteCircle(int id)
    {
        using (IUnitOfWork uow = new UnitOfWork())
        {
            using (IRepository<Circle> repo = new GenericRepository<Circle>(uow))
            {
                CircleLogic.DeleteCircle(repo, id);
            }
            uow.Save();
        }
    }
    ...
    public static class CircleLogic
    {
        public static void DeleteCircle(IRepository<Circle> repo, int id)
        {
            var circle = repo.GetById(id);
            ...
            repo.Delete(id);
        }
    }

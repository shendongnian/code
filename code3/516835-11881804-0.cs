    public interface IRepository<T>
    {
        T NewEntity();
        T AddOrUpdate(T entity);
        T GetById(int Id);
        T GetByNavigation(string NavigationString);
        IQueryable<T> All();
    }

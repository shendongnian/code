    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
    public PonyRepository : IRepository<Pony>
    {
        IEnumerable<Pony> GetAll();
    }

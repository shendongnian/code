    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
    public class PonyRepository : IRepository<Pony>
    {
        IEnumerable<Pony> GetAll();
    }

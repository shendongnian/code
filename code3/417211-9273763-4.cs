    public class CustomerFilterCriteria
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAllBy(CustomerFilterCriteria criteria);
    }

    public interface IService<T> where T : BusinessEntity { } 
    
    public interface IPersonService : IService<Person>
    {
        IEnumerable<Person> FindPersonsByAge(double minAge, double maxAge);
    }
    public class Service<T, R> : IService<T>
        where T : BusinessEntity 
        where R : IRepository<T> 
    { }
    public class PersonService : Service<Person, IPersonRepository>, IPersonService
    { }

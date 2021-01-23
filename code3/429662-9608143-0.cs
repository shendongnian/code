    public class BusinessEntity
    { }
    public class Person : BusinessEntity
    { }
    public interface IRepository<T> where T : BusinessEntity
    { }
    public interface IService<T, R>
        where T : BusinessEntity
        where R : IRepository<T>
    { }
    public partial interface IPersonRepository : IRepository<Person>
    { }
    public interface IPersonService : IService<Person, IPersonRepository>
    { }
    public abstract class BaseController<X, Y, Z>
        where X : BusinessEntity
        where Y : IService<X, Z>
        where Z : IRepository<X>
    { }
    public class PersonController : BaseController<Person, IPersonService, IPersonRepository>
    { } 

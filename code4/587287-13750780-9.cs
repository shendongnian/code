    public interface IEntity<T> { }
    //  Define a generic repository interface
    public interface IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        IEntity<TKey> Get(TKey key);
        IEnumerable<TEntity> GetRange(IEnumerable<TKey> keys);
        IEnumerable<TEntity> GetAll();
        //  ..., Update, Delete methods
    }
    //  Create an abstract class that will encapsulate the generic code
    public abstract class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        protected Repository(/*parameter you may need to implement the generic methods, like a ConnectionFactory,  table name, entity type for casts, etc */) { }
        public override void Insert(IEntity<TKey> entity)
        {
            //  do the insert, treat exceptions accordingly and encapsulate them in your own and more concise Exceptions, etc
        }
        //  ...
    }
    //  Create the entities classes, one for each table, that will represent a row of that table
    public class Car : IEntity<string> {/* Properties */}
    //  Create a specific repository for each table
    //  If the table have a composed key, just create a class representing it
    public class CarRepository : Repository<string, Car>
    {
        public CarRepository() {/* pass the base parameters */}
        // offer here your specific operations to this table entity
        public IEnumerable<Car> GetByOwner(PersonKey ownerKey)
        {
            //  do stuff
        }
    }

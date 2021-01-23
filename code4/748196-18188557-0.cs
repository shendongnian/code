    public interface IRepository
    {
        List<T> GetAll<T>() where T : IEntity;
    }
    public class TypeRate
    {
        public IRepository Repository { get; private set; } 
        public TypeRate(IRepository repository)
        {
             Repository = repository;
        }
        public List<YourType> Get()
        {
            return this.Repository.GetAll<YourType>();
        }
    }

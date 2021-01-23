    public interface IPersistable<TType>
    {
       TType PersistenceId { get; }
    }
    
    public abstract PersistableEntity<TType> : IPersistable<TType>
    {
       private TType persistenceId;
    
       public TType PersistenceId
       {
           get { return persistenceId; }
       }
    
       public PersistableEntity(TType persistenceId)
       {
          this.persistenceId = persistenceId;
       }
    }
    
    public class Customer : PersistableEntity<string>
    {
       public Customer(string persistenceId)
         : base(persistenceId)
       {
       }
    }

    //New interface for the extension of the repository.
    //Is it possible to do this without defining this new interface? Doesn't seem like it.
    public class IEntityARepository : IRepository<EntityA>
    {
       void DoSomethingSpecificToEntityA();
    }
    //Add new class.
    //It looks like you have to inherit from IEntityARepository as well.
    public class EFEntityARepository : EFRepository<EntityA>, IEntityARepository
    {
       
       public EFEntityARepository(MyDbContext context) : base(context) {}
       //add additional methods for EntityA
       public void DoSomethingSpecificToEntityA()
       {
          
       }
    
    }
    //Modify Unit of Work Interface as follows.
    public interface IUnitOfWork: IDisposable
    {
       IEntityARepository ARepository { get; }
       IRepository<EntityB> BRepository { get; }
       //...more stuff
    }
    
    //Modify Unit of Work Implementation as follows.
    public class EFUnitOfWork: IUnitOfWork
    {
       private MyDbContext context = new MyDbContext();
    
       private IEntityARepository aRepository;
       private IRepository<EntityB> bRepository;
    
       public IEntityARepository ARepository 
       {
          get
          {
                if (this.aRepository == null)
                   this.aRepository = new EFEntityARepository(context);
    
                return this.aRepository;
          }
    
       }
    
       public IRepository<EntityB> BRepository 
       {
          get
          {
                if (this.bRepository == null)
                   this.bRepository = new EFRepository<EntityB>(context);
    
                return this.bRepository;
          }
    
       }
    
       //...more stuff
    }

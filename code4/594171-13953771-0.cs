    public class RepositoryEntityBase<T> : IRepositoryEntityBase<T>, IRepositoryEF<T> where T : BaseObject
     // 
    public RepositoryEntityBase(DbContext context)
        {
            Context = context;
    //etc
  
    public interface IRepositoryEntityBase<T> : IRepositoryEvent where T : BaseObject //must be a model class we are exposing in a repository object
              
    {
        OperationStatus Add(T entity);
        OperationStatus Remove(T entity);
        OperationStatus Change(T entity);
       //etc

    public class RepositoryCustomer: RepositoryBase<Customer> 
    ...
    ...
    public class RepositoryEntityBase<T>
       public virtual T Get(Expression<Func<T, bool>> predicate)
           return Context.Set<T>.Where(predicate).FirstOrDefault();
	
	

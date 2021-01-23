    internal class CustomerService : Service<Model.Customer>
    {
      internal CustomerService(Infrastructure.IUnitOfWork uow) : base(uow)
      {   
      }
    
      internal void Add(Model.Customer customer)
      {
        Repository.Add(customer);
      }
     
      internal Model.Customer GetByID(int id)
      {
        return Repository.Find(c => c.CustomerId == id);
      }
     
    }

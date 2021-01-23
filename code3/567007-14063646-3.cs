    public class Order { // this is the domain object
      private Guid _id;
      private Status _status;
    
      // note the behavior here - we throw an exception if it's not a valid state transition
      public Cancel() {  
        if (_status == Status.Shipped)
          throw new InvalidOperationException("Can't cancel order after shipping.")
        _status = Status.Cancelled;
      }
    
      // etc...
    }
    public class Data.Order { // this is the persistence (EF) class
      public Guid Id;
      public Status Status;
    }
    
    public interface IOrderRepository {
      // The implementation of this will:
      // 1. Load the EF class if it exists or new it up with the ID if it doesn't
      // 2. Map the domain class to the EF class
      // 3. Save the EF class to the DbContext.
      void Save(Order order); 
    }

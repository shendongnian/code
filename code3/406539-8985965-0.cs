    public interface IPersistable
    {
        String PersistenceId { get; }
    }
    
    Public Class Customer : IPersistable
    {
    
        public string PersistenceId { get; private set; }
    
        public string UserId { 
             get { return PersistenceId; } 
        }
      .
      .
      .
    }

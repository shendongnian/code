    public class Client
    {
     public int ClientId { get; set; }
     public virtual ICollection<Contract> Contracts { get; set; }
    }

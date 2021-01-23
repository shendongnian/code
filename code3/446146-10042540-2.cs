    abstract class Lease
    {
      public int MonthlyCost {get;set;}
    
      public string CustomerName {get;set;}
    
      // Declare that all Leases have to have an IncreaseCost method.
      public abstract void IncreaseCost();
    }
    
    class PrivateLease : Lease
    {
      // Private leases are incremented by an absolute number (10).
      public override void IncreaseCost()
      {
        MonthlyCost += 10;
      }
    }
    
    class BusinessLease : Lease
    {
      // Business leases are incremented by 10%.
      public override void IncreaseCost()
      {
        MonthlyCost *= 1.10;
      }
    }
    
    // Somewhere in your code...
    Lease lease = new PrivateLease();
    
    // This call is polymorphic. It will use the actual type of the lease object.
    lease.IncreaseCost();

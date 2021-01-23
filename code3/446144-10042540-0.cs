    abstract class Lease
    {
      public int MonthlyCost {get;set;}
    
      public string CustomerName {get;set;}
    
      public abstract void IncreaseCost();
    }
    
    class PrivateLease
    {
      public override void IncreaseCost()
      {
        MonthlyCost += 10;
      }
    }
    
    class BusinessLease
    {
      public override void IncreaseCost()
      {
        MonthlyCost *= 1.10;
      }
    }
    
    // Somewhere in your code...
    Lease lease = new PrivateLease();
    
    // This call is polymorphic. It will use the actual type of the lease object.
    lease.IncreaseCost();

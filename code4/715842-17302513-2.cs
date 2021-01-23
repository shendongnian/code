    abstract class Employee {
      public virtual int GetBonus()
      {
        return this.Bonus;
      }
    
      public virtual int Bonus { get; set; }
    }
    
    class Manager : Employee {
      public override int Bonus 
      { 
        get { return 2000; }
      }
    }
    
    class Checkout : Employee {
      public override int Bonus
      {
        get { return 1000; }
      }
    }

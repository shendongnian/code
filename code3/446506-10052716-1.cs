    public class Caller
    {
       IContract contractor = null; 
    
    
       public void DoSomething()
       {
          contractor = new Callee();
          double value = contractor.Calculate(10.3456, -3.546456);
       }
    
    }

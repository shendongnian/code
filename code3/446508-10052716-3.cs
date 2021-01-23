    public class CallerIDE
    {
       IPlugin plugin= null; 
    
    
       public void DoSomething()
       {
          contractor = GetPlugin();
          double value = contractor.Calculate(10.3456, -3.546456);
       }
       private IPlugin GetPlugin()
       {
          return new WebConnectPlugin();
          
          return new DBConnectPlugin(); //based on some logic
       }
    
    }

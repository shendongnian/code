    public class EntryPointClass
    {
      Logger _logfile;
      // ...
      public void DoIt(string Data)
      {
         var logicClass = new MyClass();
    
         try
         {
            logicClass.DoSomething(Data);
         }
         catch(NullReferenceException ex)
         {
             _logfile.WriteLine("null reference exception occured in method 'DoIt'");
         }
      }
    }

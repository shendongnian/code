    public class SomeContext
    {
      private readonly Func<string> getUserName;
      public SomeContext(Func<string> getUserName)
      (
        this.getUserName = getUserName;
      )
    
      public void SaveSomething(\* parameters here *\)
      {
        // build your proc based on someThing plus 'this.getUserName();'
        var cmd = "Exec whatever";
        ExecuteSqlCommand(cmd);
      }
    }

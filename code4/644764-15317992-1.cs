    public class MyClass : BaseClass {
      public override string GetName() {
        return GetNameAsync().Value;
      }
      
      public async Task<string> GetNameAsync() { 
        ...
      }
    }

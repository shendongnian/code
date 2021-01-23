    [assembly: Trace("Business", AttributeTargetTypes="BusinessLayer.*")]
    namespace BusinessLayer
    {
      public class Process : IDisposable
      {
       public Customer Create(string value) { ... }
       public void Delete(long id) { ... }
       [Trace(AttributeExclude=true)]
       public void Dispose() { ... }
      }
    }

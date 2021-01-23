    [SecurityCritical]
    public class SomeCriticalClass
    {
          [SecurityCritical]
          public void Do()
          {
          }
    }
    [SecuritySafeCritical]
    public sealed class SomeClass
    {
        [SecuritySafeCritical]
        public void SomeMethod()
        {
              SomeCriticalClass critical = new SomeCriticalClass()
              
              // No more FieldAccessException!
              Action action = () => critical.Do();         
        }
    }

    public class ClassIWantToTest
    {
          public ClassIWantToTest(IServiceIWantToCall service) {}
    
          public void SomeMethod()
          {
               var results = service.DoSomething();
               //Rest of the logic here
          }
    }

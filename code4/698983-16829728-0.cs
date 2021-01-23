    public interface IHasId { 
        int Id { get; set; } 
    } 
      public class MyClass1 : IHasId
      {
          public int Id { get; set; }
      }
      public class MyClass2 : IhasId
      {
          public int Id { get; set; }
      }
    ...
    private void DoStuff<T>(T obj) 
        where T : IHasId // constraint my be move to the class declaration
    {
        int i = obj.Id(); // here is the problem
    }

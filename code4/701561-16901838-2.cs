    public abstract class Parent
    {
          public event Action Something;
      
          public void OnSomething()
          {
              if (Something != null)
              {
                  Something();
              }
          }
    }
    public class Child : Parent
    {
    
    }
    
    Child c = new Child();
    c.Something += () => Console.WriteLine("Got event from child");
    c.OnSomething();
    > Got event from child

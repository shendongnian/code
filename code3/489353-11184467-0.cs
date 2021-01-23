    public class GenericAnimal<T> 
    {
      public T Instance{get;set;}
      public int legs;
      public void Walk()
      {
          Console.WriteLine("Animals Walk....");
      }
    }

    public class Animal
    {
      public int legs;
      public void Walk()
      {
          Console.WriteLine("Animals Walk....");
      }
    }
    public class Dog : Animal
    {
       public void Bark()
        {
          Console.WriteLine("Barking....");
        }
    }
    public class Cat : Animal
    {
       public void Mew()
       {
          Console.WriteLine("Mewing....");
       }
    }

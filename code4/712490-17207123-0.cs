    public class Cat : IAnimal {
         public void Voice() {//implements IAnimal's method
             Console.WriteLine("Miyaoo");
         }
    }
    
    public class Dog: IAnimal {
         public void Voice() {  //implements IAnimal's method
             Console.WriteLine("Woof");
         }
    }
    
    public interface IAnimal {
          public void Voice();
    }

    public interface IAnimal {
    }
    
    public class Animal : IAnimal {
    }
    
    public interface ICage {
         IAnimal SomeAnimal {get;}
    }
    
    public class Cage : ICage{
         public Animal SomeAnimal { get; set; }
    }
    
    public class AnotherAnimal : IAnimal {
    }
    
    Cage c = new Cage();
    ICage ic = (ICage)c;
    ic.Animal = new AnotherAnimal();

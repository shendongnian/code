    public interface IAnimal {
    }
    
    public class Lion : IAnimal {}
    public class Sheep : IAnimal {}
    
    // note the "out" on the T type parameter
    public interface ICage<out T> where T:IAnimal {
    	 T SomeAnimal {get;}
    }
    
    public class Cage<T> : ICage<T> where T:IAnimal {
    	 public T SomeAnimal { get; set; }
    }

    public interface IAnimal
    public interface IAnimal<T> : IAnimal where T : IAnimal<T>
    
    public class Dog : IAnimal<Dog>
    public class Cat : IAnimal<Cat>

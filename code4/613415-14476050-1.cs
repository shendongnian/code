    public class Dog
    {
    }
    public class Husky : Dog
    {
    }
    public interface IAnimal<out T>
        where T : class
    {
    }
    public class Animal<T> : IAnimal<T> where T : class
    {
    }

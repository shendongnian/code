    public interface  IFood
    {
    }
    public class Animal
    {
    }
    public class Cat<T> : Animal where T : IFood
    {
        public void Eat(T food)
        {
        }
    }

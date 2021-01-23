    public abstract class Animal<T> where T: Animal<T>
    {
        public T GetAnimal 
        {
            get { return (T)this; }
        }
    }
    public class Dog : Animal<Dog>
    {
    }
    public class Cat : Animal<Cat>
    {
    }
    public class Giraffe : Animal<Giraffe>
    {
    }

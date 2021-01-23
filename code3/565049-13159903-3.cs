    public class Dog : Animal, IRunningAnimal { }
    public class Cheetah : Animal, IRunningAnimal { }
    public class Fish : Animal, ISwimmingAnimal { }
    public class Gator : Animal, ISwimmingAnimal, IRunningAnimal { }
    public interface IRunningAnimal 
    {
        public void Run();
    }
    public interface ISwimmingAnimal
    {
        public void Swim();
    }
    public abstract class Animal
    {
        /// ...
        public abstract void Move();
    }

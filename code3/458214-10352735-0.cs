    // Model
    public class Fish : IAnimal { }
    public class Tiger : IAnimal { }
    // ModelLogic
    public class Aquarium : IContainer<Fish> 
    { 
        public Fish Contents { get; set; }
    }
    // Model Interface
    public interface IAnimal { }
    // ModelLogic Interface
    public interface IContainer<T> where T : IAnimal 
    { 
        T Contents { get; set; }
    }
    IContainer<IAnimal> foo = new Aquarium(); // Why is this illegal?
    foo.Contents = new Tiger(); // Because this is legal!

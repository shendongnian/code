    interface IAnimal
    {
        // Properties
        // Methods
    }
    public abstract class Animal : IAnimal
    {
    }
    public abstract class Bird : Animal, IAttributeWings
    {
    }
    public class Pelican : Bird, IAttributeCanFly
    {
    }

    interface IAnimal
    {
        // Properties
        // Methods
    }
    public abstract class Animal : IAnimal
    {
        // Implements IAnimal properties and methods
        // This XmlElement gets written correctly when XML Serializing
        // Example:
        [XmlElement("AnimalAge")]
        public double Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
    public abstract class Bird : Animal, IAttributeWings
    {
        // Implements Attributes common for all "Birds"
        // Setting "override" here gives me error
        public bool HasWings { get { return _hasWings; } set { _hasWings = value; } }
    }
    public class Pelican : Bird, IAttributeCanFly
    {
        // Implements Attributes common for all "Pelicans"
        // Does not implement previous attribute IAttributeWings since Bird class does this
        // Setting "override" here gives me error as well
        public bool CanFly { get { return _canFly; } set { _canFly = value; } }
    }

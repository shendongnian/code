    public interface IAnimal
    {
        string SpeciesName {get; }
    }
    public class Tiger : IAnimal
    {
        public string SpeciesName { get { return "Tiger" ; } }
    }
    public class Cat : IAnimal
    {
        public string SpeciesName { get { return "Cat" ; } }
    }

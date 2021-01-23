    [ServiceKnownType(typeof(Dog))]
    [ServiceContract]
    public interface IAnimals 
    {
      public Animal GetAnimalById(string id);
    }
    public class Animals : IAnimals { [your original code] }

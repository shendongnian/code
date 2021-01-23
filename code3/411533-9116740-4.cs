    public enum AnimalType
    {
        Cat,
        Dog,
    }
    public interface ISpecificAnimalHandler
    {
        AnimalType AnimalType { get; }
        void Pet(Animal animal);
    }
    public class AnimalHandler
    {
         public AnimalHandler()
         {
             var handlers = new ISpecificAnimalHandler[] { new CatHandler(), new DogHandler() };
             this.handlersByAnimal = handlers.ToDictionary(handler => handler.AnimalType, handler);
             // ...
         }
         public void Pet(Animal animal)
         {
             ISpecificAnimalHandler handler;
             if (!this.handlersByAnimalType.TryGet(animal.AnimalType, out handler))
             {
                  throw new ArgumentOutOfRangeException("Animal of type " + animal.GetType().Name " not supported.");
             }
             handler.Pet(animal);
         }
         private IDictionary<AnimalType, ISpecificAnimalHandler> handlerByAnimalType;
    }
    public class CatHandler : ISpecificAnimalHandler
    {
        public AnimalType AnimalType
        {
            get { return AnimalType.Cat;
        }
        public void Pet(Animal animal)
        {
            var cat = (Cat) animal;
            // do petting, meow
        }
    }

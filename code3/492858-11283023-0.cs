    abstract class Animal
    {
        ...
    }
    
    public static class AnimalExtensions
    {
        public static void MakeFriends(this T animal, T anotherT) where T : Animal
        {
            ...
        }
    }

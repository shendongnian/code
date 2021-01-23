    public static class AnimalFactory
    {
        public static Animal Create(int parameter)
        {
            switch(parameter)
            {
                case 0:
                    return new DogProxy();
                case 1:
                    return new CatProxy();
                default:
                    throw new ArgumentOutOfRangeException("parameter");
            }
        }
        
        private class DogProxy : Dog { }
    
        private class CatProxy : Cat { }
    }
    public abstract class Animal { }
    
    public class Dog : Animal
    {
        protected Dog() { }
    }
    
    public class Cat : Animal
    {
        protected Cat() { }
    }

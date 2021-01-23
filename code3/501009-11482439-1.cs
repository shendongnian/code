    public enum Breed { Beagle, Husky }
    
    public class Dog
    {
        public Dog(Breed breed)
        {
            this.Breed = breed;
        }
    
        public Breed Breed { get; private set; }
    }

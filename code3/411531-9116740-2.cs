    public class AnimalHandler
    {
        public void Pet(Animal animal)
        {
            PetAnimal((dynamic) animal); // will dispatch to most appropriate method at runtime
        }
        public void PetAnimal(Cat cat)
        {
            // do petting, meow
        }
        public void PetAnimal(Dog dog)
        {
            // do petting, woof
        }
    }

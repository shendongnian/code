    public abstract class Pet
    {
        public abstract void Walk();
    }
    public sealed class Dog : Pet
    {
        public override void Walk()
        {
            //Do dog things on the walk
        }
    }
    public sealed class Iguana : Pet
    {
        public override void Walk()
        {
            //Do iguana things on the walk
        }
    }
    public sealed class PetWalker
    {
        public void Walk(Pet pet)
        {
            //Do things you'd use to get ready for walking any pet...
            pet.Walk(); //Walk the pet
            //Recover from the ordeal...
        }
    }

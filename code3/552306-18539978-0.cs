    using System.Data;
    using System.Data.Entity;
    using System.Diagnostics;
    public class Animal
    {
        public long Id { get; set; }
    }
    public class Dog : Animal
    {
    }
    public class AnimalsContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
    }
    public class Tester
    {
        public void Test()
        {
            var context = new AnimalsContext();
            var genericAnimal = new Animal();
            context.Animals.Add(genericAnimal);
            context.SaveChanges();
            // Make a new clean entity, but copy the ID (important!)
            var dog = new Dog { Id = genericAnimal.Id, };
            // Do the old switch-a-roo -- detach the existing one and attach the new one
            // NOTE: the order is important!  Detach existing FIRST, then attach the new one
            context.Entry(genericAnimal).State = EntityState.Detached;
            context.Entry(dog).State = EntityState.Modified;
            context.SaveChanges();
            var thisShouldBeADog = context.Animals.Find(genericAnimal.Id);
            // thisShouldBeADog is indeed a Dog!
            Debug.Assert(thisShouldBeADog is Dog);
            // And, of course, all the IDs match because it's the same entity
            Debug.Assert((genericAnimal.Id == dog.Id) && (dog.Id == thisShouldBeADog.Id));
        }
    }

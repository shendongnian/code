    public class Animal
    {
        ...
    }
    public class Cat: Animal
    {
        public void Meow(){...}
    }
    List<Cat> cats = new List<Cat>();
    cats.Add(new Cat());
    cats[0].Meow();  // Fine.
    List<Animal> animals = cats; // Pretend this compiles.
    animals.Add(new Animal()); // Also adds an Animal to the cats list, since animals references cats.
    cats[1].Meow(); // cats[1] is an Animal, so this explodes!

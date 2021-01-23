    class Animal { ... }
    class Dog : Animal { ... }
    class Cat : Animal { ... }
    List<Animal> animals = new List<Dog>(); // Seems to be possible
    animals.Add(new Dog());
    animals.Add(new Cat()); // Crashhhh!

    typeof(Animal).IsAssignableFrom(typeof(Dog)) == true;
    // you can do
    Dog spot = new Dog();
    Animal a = spot;        // assigned an Animal from a Dog
    // but not
    Animal b = new Animal();
    Dog spike = b;          // compiler complains

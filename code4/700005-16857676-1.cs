    class Animal { }
    class Cat : Animal { }
    class Dog : Animal { }
    class Program {
        static void Main(string[] args) {
            // This is a collection of collections of animals.
            HashSet<HashSet<Animal>> setOfSets = new HashSet<HashSet<Animal>>();
            // Here, we add a collection of cats to that collection.
            HashSet<Cat> cats = new HashSet<Cat>();
            setOfSets.Add(cats);
            // And here, we add a dog to the collection of cats. Sorry, kitty!
            setOfSets.First().Add(new Dog());
        }
    }

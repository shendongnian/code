    void Main()
    {
        // establish a list of animals and populate it
        Animals animals = new Animals();
        animals.Add(new Animal());
        animals.Add(new Dog());
        animals.Add(new Cat());
        animals.Add(new Animal("Cheetah"));
        
        // iterate over these animals
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.Name);
        }
    }

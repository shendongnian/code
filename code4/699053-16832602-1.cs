    class Program
    {
        static void Main(string[] args)
        {
            // Writes Woof, Woof
            IAnimal animal = new Dog();
            Console.WriteLine(animal.Speak());        
    
            // Now writes Meow
            animal = new Cat();
            Console.WriteLine(animal.Speak());
    
            // Now writes Sqwark etc
            animal = new Parrot();
            Console.WriteLine(animal.Speak());
        }
    }

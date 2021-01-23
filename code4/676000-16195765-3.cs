    using System;
    
    class Pet { }
    class Dog : Pet { }
    class Cat : Pet { }
    
    class Owner
    {
        public void HandlePet(Pet pet)
        {
            HandlePet((dynamic)pet);
        }
    
        public void HandlePet(Cat pet)
        {
            Console.WriteLine("Stroke the cat softly whispering Please don't scratch me.");
        }
    
        public void HandlePet(Dog pet)
        {
            Console.WriteLine("Stroke the dog firmly saying Who's a good boy?");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var owner = new Owner();
    
            Console.WriteLine("Handle dog first");
            owner.HandlePet(new Dog());
    
            Console.WriteLine("Handle cat second");
            owner.HandlePet(new Cat());
    
            Console.ReadKey();
        }
    }

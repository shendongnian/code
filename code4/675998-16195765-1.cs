    using System;
    
    abstract class Pet
    {
        public abstract void EatFood();
        public abstract void Play();
    
        public void BrushHair()
        {
            Console.WriteLine("Hair brushed!");
        }
    }
    class Dog : Pet
    {
        public override void EatFood()
        {
            Console.WriteLine("Eating dog food...");
        }
    
        public override void Play()
        {
            Console.WriteLine("Run around manically barking at everything.");
        }
    }
    class Cat : Pet
    {
        public override void EatFood()
        {
            Console.WriteLine("Eating cat food...");
        }
    
        public override void Play()
        {
            Console.WriteLine("Randomly choose something breakable to knock over.");
        }
    }
    
    class Owner
    {
        public void HandlePet(Pet pet)
        {
            pet.EatFood();
            pet.Play();
            pet.BrushHair();
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

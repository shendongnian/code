    using System;
    public interface IPetVisitor
    {
        void Visit(Dog dog);
        void Visit(Cat cat);
    }
    public interface IPetAcceptor
    {
        void Accept(IPetVisitor visitor);
    }
    public abstract class Pet : IPetAcceptor
    {
        public abstract void Accept(IPetVisitor visitor);
    }
    public class Dog : Pet
    {
        public override void Accept(IPetVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Cat : Pet
    {
        public override void Accept(IPetVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class PetHandler : IPetVisitor
    {
        public void Visit(Dog dog)
        {
            Console.WriteLine("Pet the dog");
        }
        public void Visit(Cat cat)
        {
            Console.WriteLine("Pet the cat");
        }
    }
    class Owner
    {
        private PetHandler PetHandler = new PetHandler();
        public void HandlePet(IPetAcceptor pet)
        {
            pet.Accept(PetHandler);
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

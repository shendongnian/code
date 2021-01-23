    using System;
    public interface IPetVisitor
    {
        void Visit(Dog dog);
        void Visit(Cat cat);
    }
    public interface IPetAcceptor<T>
    {
        void Accept(T visitor);
    }
    public abstract class Pet : IPetAcceptor<IPetVisitor>
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
    class Owner
    {
        // Private variable on owner class
        private int HandCount = 2;
        // Pet handler is an inner class so we can access the enclosing class' private member.
        public class PetHandler : IPetVisitor
        {
            private Owner Owner;
            public PetHandler(Owner owner)
            { Owner = owner; }
            public void Visit(Dog dog)
            {
                Console.WriteLine("Pet the dog with {0} hands", Owner.HandCount);
            }
            public void Visit(Cat cat)
            {
                Console.WriteLine("Pet the cat with {0} hands", Owner.HandCount);
            }
        }
        private PetHandler PetHandlerInstance;
        public Owner()
        {
            PetHandlerInstance = new PetHandler(this);
        }
        public void HandlePet(IPetAcceptor<IPetVisitor> pet)
        {
            pet.Accept(PetHandlerInstance);
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

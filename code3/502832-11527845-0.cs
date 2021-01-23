    class Animal
    {
        string Name { get; set; }
        abstract public Handle(IAnimalHandler handler);
    }
    class Cat : Animal
    { 
        public overrides Handle(IAnimalHandler handler)
        {
            handler.Handle(this); // Chooses the right overload at compile time!
        }
    }
    
    class Dog : Animal
    { 
        public overrides Handle(IAnimalHandler handler)
        {
            handler.Handle(this); // Chooses the right overload at compile time!
        }
    }
    interface IAnimalHandler
    {
        void Handle(Cat cat);
        void Handle(Dog dog);
    }
    class AnimalHandler : IAnimalHandler
    {
        public void Handle(Cat cat)
        {
            Console.Write("it's cat {0}", cat.Name);
        }
        public void Handle(Dog dog)
        {
            Console.Write("it's dog {0}", dog.Name);
        }
    }

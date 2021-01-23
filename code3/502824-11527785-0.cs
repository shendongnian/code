    class Dog
    {
       public string Name { get; set; }
    }
    class Cat
    {
        public string Name { get; set; }
    }
    interface IAnimalHandler<T>
    {
        void Handle(T eval);
    }
    class DogHandler : IAnimalHandler<T>
    {
        public void Handle(T eval)
        {
            // do whatever
        }
    }
    class CatHandler : IAnimalHandler<T>
    {
        public void Handle(T eval)
        {
            // do whatever
        }
    }    

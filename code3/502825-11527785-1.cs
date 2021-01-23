    class Dog { }
    class Cat { }
    interface IHandler<T>
    {
        void Handle(T eval);
    }
    class DogHandler : IHandler<Dog>
    {
        public void Handle(Dog eval)
        {
            // do whatever
        }
    }
    class CatHandler : IHandler<Cat>
    {
        public void Handle(Cat eval)
        {
            // do whatever
        }
    }    

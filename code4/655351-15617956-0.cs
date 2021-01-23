    interface IAnimal { void Eat(); }
    class Tiger : IAnimal 
    { 
      public void Eat() { ... }
      public void Pounce() { ... } 
    }
    class Giraffe : IAnimal 
    ...
    public void Subscribe<T>(Action<T> callback) where T: IAnimal
    {
       Action<IAnimal> myAction = callback; // doesn't compile but pretend it does.
       myAction(new Giraffe()); // Obviously legal; Giraffe implements IAnimal
    }
    ...
    Subscribe<Tiger>((Tiger t)=>{ t.Pounce(); });

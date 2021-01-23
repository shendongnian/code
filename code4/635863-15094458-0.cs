    class Animal
    {
       public virtual bool Speak() { //return true.  Assume all animals make a sound }
    }
    
    class Dog : Animal
    {
      public override bool Speak() { //Bark and return base.Speak() }
    }

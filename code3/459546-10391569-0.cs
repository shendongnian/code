    class B
    {
      public virtual void M(Animal animal) { ... }
    }
    class D : B
    {
      public override void M(Giraffe animal) { ... }
    }
 
    B b = new D();
    b.M(new Tiger());

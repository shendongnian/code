    class Foo : IFoo<Fruit>
    {
      public void M(Action<Fruit> action)
      {
         action(new Apple()); // An apple is a fruit.
      }
    }
    ...
    IFoo<Fruit> iff = new Foo();
    IFoo<Banana> ifb = iff; // Contravariant!
    ifb.M(banana=>banana.Peel());

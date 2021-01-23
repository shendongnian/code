     List<Animal> animals = new List<Animal>() { new Dog(), new Cat() };
     foreach (var animal in animals)
          animal.DoSomething();
--
    class Animal
    { public virtual void DoSomething() { } }
    class Cat : Animal
    { public override void DoSomething() { Console.WriteLine("CAT"); } }
    class Dog : Animal
    { public override void DoSomething() { Console.WriteLine("DOG"); } }

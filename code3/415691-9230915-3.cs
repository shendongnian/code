    Stack<Mammal> mammals = new Stack<Mammal>();
    IPop<Animal> animals = mammals;
    IPush<Giraffe> giraffes = mammals;
    IPush<Tiger> tigers = mammals;
    giraffes.Push(new Giraffe());
    tigers.Push(new Tiger());
    System.Console.WriteLine(animals.Pop()); // Tiger
    System.Console.WriteLine(animals.Pop()); // Giraffe

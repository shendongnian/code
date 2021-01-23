    var provider = new EventProviderContainer(
        new TestEventProvider("a", 1000),
        new TestEventProvider("b", 1300),
        new TestEventProvider("c", 1600));
    provider.OnEvent().Subscribe(Console.WriteLine);
    Console.ReadLine();

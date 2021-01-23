    var counter = 0;
    var sub = Substitute.For<IFoo>();
    sub.When(x => x.Bar()).Do(x => counter++);
    sub.Bar();
    Console.WriteLine(counter);  // prints 1
    sub.When(x => x.Bar()).Do(x => counter--);
    sub.Bar();
    Console.WriteLine(counter);  // prints 1, as counter gets inc'd to 2, then dec'd to 1

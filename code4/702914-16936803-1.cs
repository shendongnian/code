    Quantities q1 = new Quantities { Unit = "K", Quant = 1000};
    Console.WriteLine(q1.Quant); // Prints 1
    // Make a copy of q1
    Quantities q2 = new Quantities{ Unit = q1.Unit, Quant = q1.Quant };
    Console.WriteLine(q2.Quant); // Prints 0

    int cats;
    if (Int32.Parse(Console.ReadLine(), out cats)) {
      price = cats * 239.99;
      // go on here
    } else {
      Console.WriteLine("The number of cats must be an integer.");
    }

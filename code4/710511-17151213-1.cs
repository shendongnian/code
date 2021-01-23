    string pi = "π"; // Mmmm. I like pi.
    if (IsStringValidForCodePage(pi, 1252))
        Console.WriteLine("Pi is ok in 1252");
    else
        Console.WriteLine("Pi is NOT ok in 1252"); // Prints NOT ok.
    if (IsStringValidForCodePage(pi, 1253))
        Console.WriteLine("Pi is ok in 1253");  // Prints ok.
    else
        Console.WriteLine("Pi is NOT ok in 1253");

    // Creating an array of numbers
    var numbers = new[] { 1, 2, 3 };
    
    // Trying to prepend any value of the same type
    var results = numbers.Prepend(0);
    // output is 0, 1, 2, 3
    Console.WriteLine(string.Join(", ", results ));

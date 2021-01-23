    // Read a line of input
    string input = Console.ReadLine();
    int value;
    // Try to parse the input into an Int32
    if (Int32.TryParse(input, out value)) {
        // Parse was successful, so cast value to a char and print it
        char c = (char)value;
        Console.WriteLine(c);
    }

    // 'Regex' is in the System.Text.RegularExpressions namespace.
    
    Regex MyPattern = new Regex(@"([a-zA-Z\s]*), ([a-zA-Z\s]*), ([0-9]{4})");
    
    if (MyPattern.IsMatch("Arnold Zend, Red House, 2551")) {
        Console.WriteLine("String matched.");
    }

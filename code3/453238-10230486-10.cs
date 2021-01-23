    var itemValues = request.Split('+');
    foreach(var item in itemValues)
    {
        string[] tmp = item.Split('=');
    
        if (tmp.Length == 2 && !string.IsNullOrWhiteSpace(tmp[1]))
            arguments.Add(tmp[0], tmp[1]);
        else
            throw InvalidOperationException("Bad dictionary string value");
    });
    // Validate and assign
    //read values from the dictionary
    //use ContainsKey to check for exist first if needed
    Console.WriteLine(arguments["firstname"]); // Displays foo
    Console.WriteLine(arguments["lastname"]); // Displays foo
    Console.WriteLine(arguments["amout"]); // Displays 100.58

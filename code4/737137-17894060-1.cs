    var acceptedValues = new List<string>()
    {
        "a",
        "b",
    };
    Console.WriteLine("Please enter {0}", string.Join("or", acceptedValues));
    var enteredValue = string.Empty;
    do
    {
        enteredValue = Console.ReadLine().ToLower();
    } while (!acceptedValues.Contains(enteredValue));

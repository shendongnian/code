    Console.Write(new Salutation
    {
        Name = "Alice",
        Age = 35,
        RevealAge = false
    }.TransformText());
    
    Console.Write(new Salutation
    {
        Name = "Bob",
        Age = 38,
        RevealAge = true
    }.TransformText());

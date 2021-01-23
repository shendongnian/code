    double red;
    Console.Write("Red = ");
    var input = Console.ReadLine();
    
    if(!double.TryParse(input, out red))
    {
        Console.WriteLine("You have not entered an appropriate value!");
    }

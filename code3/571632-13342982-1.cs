    var input = Console.ReadLine();
    int number;
    if (int.TryParse(input, out number))
    {
        if (number > 0 && number < 10)
            Console.WriteLine("The right number!!");
        else
            Console.WriteLine("The wrong number!!");
    }
    Console.ReadLine();

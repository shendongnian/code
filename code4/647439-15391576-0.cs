    int val = 0;
    while(!int.TryParse(Console.ReadLine(),out val))
    {
        Console.WriteLine("Invalid number, try again!");
    }
    // here "val" will have your integer

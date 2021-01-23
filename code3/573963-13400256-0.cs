    bool userNum = true;
    double userDouble;
    while (userNum)
    {      
        string userString = Console.ReadLine();
        // Jesli sa liczby to convertujemy
        if (userNum = double.TryParse(userString, out userDouble))
        {
            userDouble = Convert.ToDouble(userString);
            userNum = false;
        }
        else 
        {
            Console.WriteLine("Nie podano liczby!");
            userNum = true;
        }
    }

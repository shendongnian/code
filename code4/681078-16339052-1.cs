    bool valid;
    while (!valid)
    {
        Console.WriteLine("Anna arvaus");
        int.TryParse(Console.ReadLine(),out pyöräytys);
        valid = (pyöräytys > 0 && pyöräytys <= 6);
    }

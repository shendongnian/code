    pyöräytys = -1; // Set to invalid to trigger loop
    
    while (pyöräytys < 1 || pyöräytys > 6)
    {
       Console.WriteLine("Anna arvaus");
       int.TryParse(Console.ReadLine(),out pyöräytys);
       if (pyöräytys < 1 || pyöräytys > 6)
       {
           Console.WriteLine("Invalid value, must be 1-6"); // Error message
       }
    }

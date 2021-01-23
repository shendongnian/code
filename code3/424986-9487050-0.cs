    public void PrintName<T>(T someT)
    {
        // This is assuming you want it based on the type of T,
        // not the type of the value of someT
        if (typeof(DerivedT).IsAssignableFrom(typeof(T))
        {
            PrintName((DerivedT)(object) someT);
            return;
        }
        Console.WriteLine("PrintName<T>(T someT)"); 
    }

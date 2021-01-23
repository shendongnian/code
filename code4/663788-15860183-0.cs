    if ( obj.GetType() == typeof( A ) )
    {
        Console.WriteLine(((A)obj).Name);
    }
    else if ( obj.GetType() == typeof( B ) )
    {
        Console.WriteLine(((B)obj).Name);
    }

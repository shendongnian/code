    public static P WorkWithI(P p)
    {
        var i = p as I; // I would prefer as instead of is (see boxing/unboxing in .net)
        if (i != null)
        {
           // do what you want with concrete class I in i
        }
            
        return i; // <- this is important for Evaluation
    }
    

    public static void Main()
    {
        var factory = new CFactory();
        var c1 = factory.NewC("string", "string", true);
        var c2 = factory.NewC("string2", "string2", false);
    
        foreach(var c in factory.CreatedC)
        {
            //loops over c1 and c2
        }
    }

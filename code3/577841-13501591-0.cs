    public bool Equals(Type t1, Type t2)
    {
        var t1Constructors = t1.GetConstructors();
        var t2Constructors = t2.GetConstructors();
        //compare constructors
        var t1Methods = t1.GetMethods();
        var t2Methods = t2.GetMethods();
        //compare methods
        //etc.
    }

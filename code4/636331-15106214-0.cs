    // BaseClass gets to decide which concrete class to return
    public static BaseClass GetInstance()
    {
        return new DerivedClass();
    }

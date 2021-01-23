    public static void main()
    {
        DerivedClass derivedObj = new DerivedClass();
        **BaseClass obj2 = (BaseClass)derivedObj;
        obj2.Method1();  // invokes Baseclass method**
    }
}`

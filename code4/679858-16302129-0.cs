    public static void MyBaseClassStaticMethod(MyBaseClass callingInstance)
    {
        MyDerivedClass myDerivedClass = callingInstance as MyDerivedClass;
        MyDerivedClass2 myDerivedClass2 = callingInstance as MyDerivedClass2;
        MyDerivedClass3 myDerivedClass3 = callingInstance as MyDefivedClass3;
        ...
        
        // test for which derived class is calling
        if (myDerivedClass != null)
            ...
        else if (myDerivedClass2 != null)
            ...
        
        ...
    }

    void SomeConsumingMethod()
    {
        ...
        IBase x = serviceObject.Parse(xDocument);
        // Members declared in IBase:
        x.SomeMethod();
        // Members declared in ITypeA or ITypeB
        if (x is ITypeA)
            ((ITypeA)x).A();
        if (x is ITypeB)
            ((ITypeB)x).B();
    }

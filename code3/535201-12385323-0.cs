    class BaseClass {}
    class ConcreteClass1 : BaseClass
    {
        void Display1 () {}
    }
    class ConcreteClass2 : BaseClass
    {
        void Display2 () {}
    }
    void Enumerate (List<BaseClass> baseItems)
    {
        foreach (BaseClass baseItem in baseItems)
        {
            ConcreteAccessor ((dynamic)baseItem);
        }
    }
    void ConcreteAccessor (ConcreteClass1 concreteItem1)
    {
        concreteItem1.Display1 ();
    }
    void ConcreteAccessor (ConcreteClass2 concreteItem2)
    {
        concreteItem2.Display2 ();
    }    

    object TheMethod(MyEnum type)
    {
        if (type == MyEnum.A) return (object)SubMethod1();
        else if (type == MyEnum.B) return (object)SubMethod2();
        //...
    }
    
    int SubMethod1() { return 1; }
    string SubMethod2() { return "a"; }

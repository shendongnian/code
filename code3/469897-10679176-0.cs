    bool SomeOtherFunction(int arg1, out int argOut){ ... }
    
    bool SomeOtherFunction(int arg1)
    {
        int dummyArgOut;
        return SomeOtherFunction(arg1, dummyArgOut);
    }

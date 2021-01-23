    public struct ParamsStruct
    {
        Type1 param1;
        Type2 param2;
        ...
    }
    public void Method(ParamsStruct p)
    {
        ...
    }
    public void Main(String[] args)
    {
        ParamsStruct p;
        p.param1 = ...
        p.param2 = ...
        Method(p);
    }

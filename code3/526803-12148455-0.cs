    public void Test()
    {
        foo(y: genNum(), x: genNum());
    }
    int X=0;
    int genNum()
    {
        return ++X;
    }
    void foo(int x, int y)
    {
        Console.WriteLine(x);
        Console.WriteLine(y);
    }

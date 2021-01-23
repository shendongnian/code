    static void highMem()
    {
        var r = new Random();
        var o = new MyClass();
        o.MyClassEvent += a => { };
    }
    static void Main(string[] args)
    {
        highMem();
        GC.Collect(); //yes, it was collected
    }

    public delegate void Del();
    private class Locals
    {
        public int x;
        public void AnonymousMethod() { x++; }
    }    
    public void Fun()
    {
        Locals locals = new Locals();
        locals.x = 5;
        Del d = locals.AnonymousMethod;
        MyFun(d);
        Console.WriteLine(locals.x);
    }
    
    public static void MyFun(Del d)
    {
        d();
    }

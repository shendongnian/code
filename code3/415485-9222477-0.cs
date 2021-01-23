    public static void Main(String[] args)
    {
        Foo f = new Foo();
        Console.WriteLine(ForMethod<Action>(() => f.FooMethod()).Name);
        Console.WriteLine(ForMethod<Action>(() => f.BarMethod("foo")).Name);
        Console.ReadKey();
    }
    public static MethodInfo ForMethod<T>(Expression<T> e)
    {
        return ((MethodCallExpression)e.Body).Method;
    }
    class Foo
    {
        public void FooMethod() { }
        public void BarMethod(String foo) { }
    }

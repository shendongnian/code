    public static void Main(String[] args)
    {
        Foo f = new Foo();
        Console.WriteLine(ForMethod(() => f.FooMethod()).Name);
        Console.WriteLine(ForMethod(() => f.Foo2Method<String>()).Name);
        Console.WriteLine(ForMethod(() => f.BarMethod("foo")).Name);
        Console.ReadKey();
    }
    public static MethodInfo ForMethod(Expression<Action> e)
    {
        var mi = ((MethodCallExpression) e.Body).Method;
        if (mi.IsGenericMethod)
            mi = mi.GetGenericMethodDefinition();
        return mi;
    }
    class Foo
    {
        public void FooMethod() { }
        public void Foo2Method<T>() { }
        public void BarMethod(String foo) { }
    }

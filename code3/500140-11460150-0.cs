    static void Main()
    {
        var fooType = typeof(Foo); // get type via any method
        int i = 0;
        
        Action<object> doSomething = (foo) => i += (int)foo.GetType().GetMethod("GetNumber").Invoke(foo, null);
        var typedDoSomething = (typeof(Program)).GetMethod("DelegateHelper").MakeGenericMethod(fooType).Invoke(null, new object[] { doSomething });
        
        var myFoo = Activator.CreateInstance(fooType);
        fooType.GetMethod("UseFoo").Invoke(myFoo, new object[] { typedDoSomething });
        Console.WriteLine(i);
    }
        
    public static Action<T> DelegateHelper<T>(Action<object> generic)
    {
        return x => generic(x);
    }
 

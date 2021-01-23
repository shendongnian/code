    static void Main(string[] args)
    {
        var list = new List<WeakReference>();
        //var obj = new TestObject("Hello 1");
        list.Add(new WeakReference(new TestObject("Hello 1").GetMethod()));
        Console.WriteLine("Initial obj: " + ((Delegate)list[0].Target).DynamicInvoke());      //Works fine
        //obj = null;     //Now, obj is set to null, the TestObject("Hello 1") can be collected by GC
        GC.Collect();   //Force GC
        //Console.WriteLine("Is obj null: " + ((obj) == null ? "True" : "False"));
        Console.WriteLine("After GC collection: " + ((Delegate)list[0].Target).DynamicInvoke());
        Console.ReadKey();
    }

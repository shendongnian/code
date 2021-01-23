    void Main()
    {
        // Manual test first
        MyClass c = new MyClass("MyClass");
        c.Do(":D");
        
        var method = new DynamicMethod("dummy", null, Type.EmptyTypes);
        var il = method.GetILGenerator();
        
        // <stack> = new MyClass("MyClass");
        il.Emit(OpCodes.Ldstr, "MyClass");
        il.Emit(OpCodes.Newobj, typeof(MyClass).GetConstructor(new[] { typeof(string) }));
        
        // <stack>.Do(":D");
        il.Emit(OpCodes.Ldstr, ":D");
        il.Emit(OpCodes.Call, typeof(MyClass).GetMethod("Do", new[] { typeof(string) }));
        
        // return;
        il.Emit(OpCodes.Ret);
        
        var action = (Action)method.CreateDelegate(typeof(Action));
        action();
    }
    
    public class MyClass
    {
        public MyClass(string text)
        {
            Console.WriteLine("MyClass(" + text + ")");
        }
        
        public void Do(string text)
        {
            Console.WriteLine("Do(" + text + ")");
        }
    }

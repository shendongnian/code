    void Main()
    {
        var typeHandle = typeof(Foo).TypeHandle
            .Value.ToInt64();
        Console.WriteLine("addressOf(typeof(Foo)): 0x{0:x}", 
             typeHandle);
     
        var instanceMethod1 = typeof(Foo).GetMethod("InstanceFunc1");
        System.Runtime.CompilerServices.RuntimeHelpers
              .PrepareMethod(instanceMethod1.MethodHandle);
        var addressOfInstanceMethod1 = instanceMethod1.MethodHandle
              .GetFunctionPointer().ToInt64();
        Console.WriteLine("foo.InstanceFunc1:      0x{0:x}", 
               addressOfInstanceMethod1);
    
        var instanceMethod2 = typeof(Foo)
               .GetMethod("InstanceFunc2");
        System.Runtime.CompilerServices.RuntimeHelpers
               .PrepareMethod(instanceMethod2.MethodHandle);
        var addressOfInstanceMethod2 = instanceMethod2.MethodHandle
               .GetFunctionPointer().ToInt64();
        Console.WriteLine("foo.InstanceFunc2:      0x{0:x}", 
                addressOfInstanceMethod2);
    
        var staticMethod = typeof(Foo).GetMethod("StaticFunc");
        System.Runtime.CompilerServices.RuntimeHelpers
                .PrepareMethod(staticMethod.MethodHandle);
        var addressOfStaticMethod = staticMethod.MethodHandle
                .GetFunctionPointer().ToInt64();
        Console.WriteLine("Foo.StaticFunc:         0x{0:x}", 
                addressOfStaticMethod);
    }
    
    public class Foo
    {
       public static int StaticFunc() { return 1; }	
       public int InstanceFunc1() { return 1; }	
       public int InstanceFunc2() { return 1; }
    }

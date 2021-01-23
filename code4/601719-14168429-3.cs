    using System;
    using System.Runtime.CompilerServices;
    void Main()
    {
        long typeHandle = typeof(Foo).TypeHandle.Value.ToInt64();
        Console.WriteLine("addressOf(typeof(Foo)): 0x{0:x}", typeHandle);
     
        MethodInfo instanceMethod1 = typeof(Foo).GetMethod("InstanceFunc1");
        RuntimeHelpers.PrepareMethod(instanceMethod1.MethodHandle);
        long addressOfInstanceMethod1 = instanceMethod1.MethodHandle.GetFunctionPointer().ToInt64();
        Console.WriteLine("foo.InstanceFunc1:      0x{0:x}", addressOfInstanceMethod1);
    
        MethodInfo instanceMethod2 = typeof(Foo).GetMethod("InstanceFunc2");
        RuntimeHelpers.PrepareMethod(instanceMethod2.MethodHandle);
        long addressOfInstanceMethod2 = instanceMethod2.MethodHandle.GetFunctionPointer().ToInt64();
        Console.WriteLine("foo.InstanceFunc2:      0x{0:x}", addressOfInstanceMethod2);
    
        MethodInfo staticMethod = typeof(Foo).GetMethod("StaticFunc");
        RuntimeHelpers.PrepareMethod(staticMethod.MethodHandle);
        long addressOfStaticMethod = staticMethod.MethodHandle.GetFunctionPointer().ToInt64();
        Console.WriteLine("Foo.StaticFunc:         0x{0:x}", addressOfStaticMethod);
    }
    
    public class Foo
    {
       [MethodImpl(MethodImplOptions.NoInlining)]
       public static int StaticFunc() { return 1; }	
       [MethodImpl(MethodImplOptions.NoInlining)]
       public int InstanceFunc1() { return 1; }	
       [MethodImpl(MethodImplOptions.NoInlining)]
       public int InstanceFunc2() { return 1; }
    }

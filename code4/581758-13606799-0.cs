    using Microsoft.CSharp.RuntimeBinder;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    public class Foo
    {
        public object Bar() { return "I was here"; }
    }
    static class Program
    {
        static void Main()
        {
            object obj = new Foo();
            object result = DynamicCallWrapper.Invoke(obj, "Bar");
            Console.WriteLine(result);
        }
    }
    
    static class DynamicCallWrapper
    {
        // Hashtable has nice threading semantics
        private static readonly Hashtable cache = new Hashtable();
        public static object Invoke(object target, string methodName)
        {
            object found = cache[methodName];
            if (found == null)
            {
                lock (cache)
                {
                    found = cache[methodName];
                    if(found == null)
                    {
                        cache[methodName] = found = CreateCallSite(methodName);
                    }
                }
            }
            var callsite = (CallSite<Func<CallSite, object,object>>)found;
            return callsite.Target(callsite, target);
        }
        static object CreateCallSite(string methodName)
        {
            return CallSite<Func<CallSite, object, object>>.Create(
                Binder.InvokeMember(
                CSharpBinderFlags.None, methodName, null, typeof(object),
                new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(
                         CSharpArgumentInfoFlags.None, null) }));
    
        }
    }

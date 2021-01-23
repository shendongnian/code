    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    class Program
    {
        static void Main()
        {
            var writeLine = CreateDelegate(typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }));
            writeLine.DynamicInvoke("Hello world");
    
            var readLine = CreateDelegate(typeof(Console).GetMethod("ReadLine", Type.EmptyTypes));
            writeLine.DynamicInvoke(readLine.DynamicInvoke());
        }
    
        static Delegate CreateDelegate(MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }
    
            if (!method.IsStatic)
            {
                throw new ArgumentException("The provided method must be static.", "method");
            }
    
            if (method.IsGenericMethod)
            {
                throw new ArgumentException("The provided method must not be generic.", "method");
            }
    
            return method.CreateDelegate(Expression.GetDelegateType(
                (from parameter in method.GetParameters() select parameter.ParameterType)
                .Concat(new[] { method.ReturnType })
                .ToArray()));
        }
    }

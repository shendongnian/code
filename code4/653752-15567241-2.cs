    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Dynamic;
    public class Program
    {
        public class MyCallable<T1, T2> : DynamicObject
        {
            private readonly Expression<Func<T1, T2> > _wrapped;
            private readonly Func<T1, T2> _compiled;
    
            public MyCallable(Expression<Func<T1, T2>> towrap) 
            { 
                _wrapped = towrap; _compiled = _wrapped.Compile(); 
            }
    
            public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
            {
                if ( (args.Length == 1) && 
                     (args[0].GetType() == typeof(T1)))
                {
                    Console.WriteLine(@"Invoking ""{0}"" on {1}", _wrapped, args[0]);
                    result = _compiled((T1) args[0]);
                    return true;
                }
                else
                {
                    //throw new ArgumentException("Cannot invoke " + _wrapped + " with the arguments passed");
                    result = null;
                    return false;
                }
            }
        }
    
        public static class TheormProver
        {
            public static object[] NewTheorm() { return new object[] { 1 }; }
            public static dynamic Func<T1, T2>() { return new MyCallable<T1, T2>(arg1 => default(T2)); }
            public static int Int { get; set; }
        }
    
        public static void Main(string[] args)
        {
            var i = 123;
            var test2 = from t in TheormProver.NewTheorm()
                let f = TheormProver.Func<int, bool>()
                let a = TheormProver.Int
                let g = TheormProver.Func<bool, int>()
                where !f(a * 2) && g(f(g(f(4)))) == i * a && a < g(f(a))
                select new { f = f.ToString(), g = g.ToString(), a, asd = "Test extra property" };
    
            test2.ToList().ForEach(Console.WriteLine);
        }
    
    }

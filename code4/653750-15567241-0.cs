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

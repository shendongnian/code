    public static class Exceptional
    {
        public static IExceptional<TValue> ToExceptional<TValue>(this TValue result)
        {
            return new Value<TValue>(result);
        }
        public static IExceptional<TValue> ToExceptional<TValue,TException>(this TException exception) where TException : System.Exception
        {
            return new Exception<TValue, TException>(exception);
        }
     
     
        public static IExceptional<TResultOut> Bind<TResultIn, TResultOut>(this IExceptional<TResultIn> first, Func<TResultIn, IExceptional<TResultOut>> func)
        {                
            return first.IsException() ? 
                    ((IInternalException)first).Copy<TResultOut>() : 
                    func(first.Value());
        }
     
     
        public static IExceptional<TResultOut> SelectMany<TResultIn, TResultBind, TResultOut>(this IExceptional<TResultIn> first, Func<TResultIn, IExceptional<TResultBind>> func, Func<TResultIn, TResultBind, TResultOut> select)
        {
            return first.Bind(aval => func(aval)
                        .Bind(bval => select(aval, bval)
                        .ToExceptional()));
        }   
    }

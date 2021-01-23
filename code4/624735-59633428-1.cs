Try(() => UpdateSweetGreen("21", SweetGreen))
.Catch(LogToDb(e.Message))
.Catch(LogToFile(e.Message).Finally(ReportNewSweetGreen(SweetGreen);
Basically a CatchWrapper extends TryWrapper. So you could catch an exception off of another catch block. In this instance logging a failure of your method to a database, then if that fails to a file, then no matter what reporting the SweetGreen variable to some other component.
###This all extends from TryWrapper###
C
    public class TryWrapper<T>
    {
        protected internal T Result { get; set; } = default(T);
        protected internal Exception Exception { get; set; } = null;
        public static implicit operator T(TryWrapper<T> wrapper)
        {
            return wrapper.Result;
        }
        public static implicit operator Exception(TryWrapper<T> wrapper)
        {
            return wrapper.Exception;
        }
    }
###and CatchWrapper which simply extends TryWrapper and cannot be invoked directly, instead only appearing after a try as you'd expect with standard implementation###
    public class CatchWrapper<T> : TryWrapper<T>
    {
    }
###Then a series of static extension methods###
        public static TryWrapper<T> Try<T>(Func<T> func)
        {
            var product = new TryWrapper<T>();
            try
            {
                product.Result = func.Invoke();
            }
            catch (Exception e)
            {
                product.Exception = e;
            }
            return product;
        }
        public static TryWrapper<T> Try<T>(Action action)
        {
            var product = new TryWrapper<T>();
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                product.Exception = e;
            }
            return product;
        }
        public static CatchWrapper<T> Catch<T>(this TryWrapper<T> wrapper, Action<Exception> response)
        {
            if (wrapper.Exception is null) return wrapper as CatchWrapper<T>;
            response.Invoke(wrapper);
            wrapper.Exception = null;
            return wrapper as CatchWrapper<T>;
        }
        public static TryWrapper<T> Finally<T>(this TryWrapper<T> wrapper, Action<T> response)
        {
            response.Invoke(wrapper);
            return wrapper;
        }
        public static TryWrapper<T> Finally<T>(this TryWrapper<T> wrapper, Func<T> response)
        {
            wrapper.Result = response.Invoke();
            return wrapper;
        }
        public static TryWrapper<T> Finally<T>(this TryWrapper<T> wrapper, Action response)
        {
            response.Invoke();
            return wrapper;
        }
Now this does achieve that inline syntax the OP was asking for but I'd hazard to say its a touch less efficient since you could just deal with the exception directly in a standard try-catch. Still kindof ocol to be able to specify the return directly before the Try, though this is risky if <T> defaults to null.

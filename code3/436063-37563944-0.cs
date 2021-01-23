    public class IsNull
    {
        public static O Substitute<I,O>(I obj, Func<I,O> fn, O nullValue=default(O))
        {
            if (obj == null)
                return nullValue;
            else
                return fn(obj);
        }
    }

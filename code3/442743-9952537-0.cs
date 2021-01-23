    public interface ITOrU { //empty interface }
    public class T : ITOrU
    {
    ...
    }
    public class U : ITOrU
    {
    ...
    }
    class Type1<T, U>
    {
        public static Type1<T, U> New<V>( V v )
            where V : ITOrU
        {
            return new Type1<T, U>();
        }
    }

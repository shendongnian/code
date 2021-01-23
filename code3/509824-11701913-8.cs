    public abstract class Numeric<T>
        where T : Numeric<T>
    {
        public static Func<T, T, T> Add;
        public static T operator +(Numeric<T> x, Numeric<T> y)
        {
            if (x == null) {
                return (T)y;
            }
            if (y == null) {
                return (T)x;
            }
            return Add((T)x, (T)y);
        }
    }

    public class RuntimeHelper
    {
        public static void CheckType<T>(this Object @this)
        {
            if (typeof(T) != @this.GetType())
                throw new ....;
        }
    }

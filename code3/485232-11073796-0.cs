    interface IConvertible<out T>
    {
        T Convert();
    }
    abstract class A
    {
    }
    abstract class A<T> : A, IConvertible<T>
    {
        public abstract T Convert();
        public static explicit operator T(A<T> a)
        {
            return a.Convert();
        }
    }
    class B : A<X>
    {
        public override X Convert()
        {
            // TODO implement this
        }
    }

    using System;
    using System.Linq.Expressions;
    struct S<T>
    {
        public static bool operator ==(S<T> a, S<T> b) { return false; }
        public static bool operator !=(S<T> a, S<T> b) { return false; }
    }
    class Program
    {
        static void Main()
        {
            Expression<Func<S<int>?, S<int>, bool>> x = (a, b) => a == b;
        }
    }

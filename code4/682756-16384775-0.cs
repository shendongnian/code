    using System;
    namespace Demo
    {
        internal class Program
        {
            static void Main()
            {
                var d = new Vector4D<double>{v1=1, v2=2, v3=3, v4=4};
                Console.WriteLine(d*2); // Prints 2, 4, 6, 8
                var i = new Vector4D<int>{v1=1, v2=2, v3=3, v4=4};
                Console.WriteLine(i*2); // Prints 2, 4, 6, 8            }
        }
        partial struct Vector4D<T>
        {
            public T v1;
            public T v2;
            public T v3;
            public T v4;
            public static Vector4D<T> operator *(Vector4D<T> a, T b)
            {
                a.v1 = multiply(a.v1, b);
                a.v2 = multiply(a.v2, b);
                a.v3 = multiply(a.v3, b);
                a.v4 = multiply(a.v4, b);
                return a;
            }
            public override string ToString()
            {
                return string.Format("v1: {0}, v2: {1}, v3: {2}, v4: {3}", v1, v2, v3, v4);
            }
            private static Func<T, T, T> multiply;
        }
        // Partial just to keep this logic separate.
        partial struct Vector4D<T>
        {
            static Vector4D() // Called only once for each T.
            {
                if (typeof (T) == typeof (int))
                    Vector4D<int>.multiply = (a, b) => a*b;
                else if (typeof(T) == typeof(double))
                    Vector4D<double>.multiply = (a, b) => a*b;
                else if (typeof(T) == typeof(float))
                    Vector4D<float>.multiply = (a, b) => a*b;
            }
        }
    }

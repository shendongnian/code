    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class A
        {
            public int Value;
            public bool Matching(A a)
            {
                return a.Value == Value;
            }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
        class Program
        {
            void test()
            {
                var list1 = new List<A>();
                var list2 = new List<A>();
                for (int i = 0; i < 20; ++i) list1.Add(new A {Value = i});
                for (int i = 4; i < 16; ++i) list2.Add(new A {Value = i});
                var missing = list1.Except(list2, (a, b) => a.Matching(b));
                missing.Print(); // Prints 0 1 2 3 16 17 18 19
            }
            static void Main()
            {
                new Program().test();
            }
        }
        static class MyEnumerableExt
        {
            public static void Print<T>(this IEnumerable<T> sequence)
            {
                foreach (var item in sequence)
                    Console.WriteLine(item);
            }
        }
        public static class LINQHelper
        {
            private class LambdaComparer<T>: IEqualityComparer<T>
            {
                private readonly Func<T, T, bool> _lambdaComparer;
                private readonly Func<T, int> _lambdaHash;
                public LambdaComparer(Func<T, T, bool> lambdaComparer) :
                    this(lambdaComparer, o => 0)
                {
                }
                private LambdaComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
                {
                    if (lambdaComparer == null)
                        throw new ArgumentNullException("lambdaComparer");
                    if (lambdaHash == null)
                        throw new ArgumentNullException("lambdaHash");
                    _lambdaComparer = lambdaComparer;
                    _lambdaHash = lambdaHash;
                }
                public bool Equals(T x, T y)
                {
                    return _lambdaComparer(x, y);
                }
                public int GetHashCode(T obj)
                {
                    return _lambdaHash(obj);
                }
            }
            public static IEnumerable<TSource> Except<TSource>
            (
                this IEnumerable<TSource> enumerable, 
                IEnumerable<TSource> second, 
                Func<TSource, TSource, bool> comparer
            )
            {
                return enumerable.Except(second, new LambdaComparer<TSource>(comparer));
            }
        }
    }

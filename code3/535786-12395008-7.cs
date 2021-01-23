    using System;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var compare = new Comparer<Example, string>(example => example.id(example));
                var ex1 = new Example();
                var ex2 = new Example();
                Console.WriteLine(compare.Equals(ex1, ex2));
                Console.ReadLine();
            }
            class Example
            {
                public string id(Example example)
                {
                    return new string(new [] {'f', 'o', 'o'});
                }
            }
            class Comparer<T, TId> where TId : class 
            {
                private readonly Func<T, TId> m_idfunc;
                public Comparer(Func<T, TId> idFunc)
                {
                    m_idfunc = idFunc;
                }
                public bool Equals(T x, T y)
                {
                    var xid = m_idfunc(x);
                    var yid = m_idfunc(y);
                    return (TId)xid == (TId)yid;
                }
            }
        }
    }

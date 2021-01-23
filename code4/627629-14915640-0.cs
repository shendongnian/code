        class Foreachable
        {
            public MyEnumeratorType GetEnumerator()  // OK, public, non-static, non-generic, zero arguments
            {
                return default(MyEnumeratorType);
            }
        }
        struct MyEnumeratorType
        {
            public int Current
            {
                get { return 42; }
            }
            public bool MoveNext()
            {
                return true;
            }
        }
        static class Test
        {
            static void Main()
            {
                var coll = new Foreachable();
                foreach (var x in coll)   // mouse-over 'var' to see it translates to 'int'
                {
                    Console.WriteLine(x);
                }
            }
        }

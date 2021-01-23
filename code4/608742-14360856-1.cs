    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace Demo
    {
        internal class Program
        {
            private static void Main()
            {
                var test = new MyDemo();
                foreach (int item in test)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public class MyDemo: IEnumerable<int>
        {
            public IEnumerator<int> GetEnumerator()
            {
                // Your implementation of this method will iterate over your nodes
                // and use "yield return" to return each one in turn.
                for (int i = 10; i <= 20; ++i)
                {
                    yield return i;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }

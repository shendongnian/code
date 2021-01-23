    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test test = new Test();
                var dict = new Dictionary<Test, Test>();
                dict.Add(test, test);
            }
        }
        public class Test
        {
            public string Value
            {
                get;
                set;
            }
            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }
        }
    }

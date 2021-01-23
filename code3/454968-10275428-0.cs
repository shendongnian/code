    using System;
    using System.Collections.Generic;
    namespace AddGenericToList
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tc = new ListClass<string>();
                tc.Add("a value");
                tc.Add(123);
                tc.Add(DateTime.Now);
            }
        }
        internal class ListClass<T>
        {
            private readonly List<T> list = new List<T>();
            public void Add(object value)
            {
                list.Add((T)Convert.ChangeType(value, Nullable.GetUnderlyingType(typeof (T)) ?? typeof (T)));
            }
        }
    }

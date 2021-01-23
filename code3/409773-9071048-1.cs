    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ClassLibrary1
    {
    public class Class1
    {
        public int A;
        public int B;
    }
    public class Test
    {
        public static IEnumerable<dynamic> Build()
        {
            var list = new List<Class1>();
            list.Add(new Class1() { A = 10, B = 100 });
            list.Add(new Class1() { A = 200, B = 2000 });
            return list
                .OrderBy(e => e.B)
                .Select(e => new { A1 = e.A, B2 = e.B });
        }
        public static IEnumerable<dynamic> Filter()
        {
            return Build()
                .Where(e => e.A1 > 100);
        }
        static void Main()
        {
            foreach (dynamic e in Filter())
                Console.WriteLine("A1={0}, B2={1}", e.A1, e.B2);
        }
    }
    }

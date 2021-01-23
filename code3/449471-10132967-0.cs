    using System;
    using System.Collections;
    
    public class Test : IEnumerable
    {
        static void Main()
        {
            var t = new Test
            {
                "hello",
                { 5, 10 },
                { "whoops", 10, 20 }
            };
        }
        
        public void Add(string x)
        {
            Console.WriteLine("Add({0})", x);
        }
        
        public void Add(int x, int y)
        {
            Console.WriteLine("Add({0}, {1})", x, y);
        }
        
        public void Add(string a, int x, int y)
        {
            Console.WriteLine("Add({0}, {1}, {2})", a, x, y);
        }
        
        IEnumerator IEnumerable.GetEnumerator()        
        {
            throw new NotSupportedException();
        }
    }

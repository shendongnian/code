    using System;
    using System.Collections.Generic;
    using AutoMapper;
    
    public class A
    {
        public int a { get;set; }
        public string b { get;set; }
        public List<int> ints { get;set; }
    }
    
    public class B
    {
        public int a { get;set; }
        public string b { get;set; }
        public List<int> ints { get;set; }
    }
    
    class Program
    {
        static void Main()
        {
            Mapper.CreateMap<B, A>();
            var b = new B
            {
                a = 1,
                b = "foo",
                ints = new List<int>(new[] { 1, 2, 3, 4 })
            };
            var a = Mapper.Map<B, A>(b);
            Console.WriteLine(a.ints.Count);
            foreach (var item in a.ints)
            {
                Console.WriteLine(item);
            }
        }
    }

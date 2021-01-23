    using System;
    using AutoMapper;
    class Program
    {
        static void Main(string[] args)
        {
            B b = Mapper.Map<A, B>(new A());
            Console.WriteLine(b.GetType()); //A
            Mapper.CreateMap<A, B>();       //define the mapping
            b = Mapper.Map<A,B>(new A());
            Console.WriteLine(b.GetType()); //B
            Console.ReadLine();
        }
    }
    public class A: B
    {
    }
    public class B
    {
    }

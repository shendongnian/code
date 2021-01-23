    using System;
    
    public abstract class A<T> where T : new()
    {
        public static T CreateInstance()
        {
            return new T();
        }
    }
    
    public class B : A<int>
    {
    }
    
    class Test
    {
        static void Main()
        {
            Console.WriteLine(B.CreateInstance());
        }
    }

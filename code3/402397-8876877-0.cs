    using System;
    
    public abstract class BuilderBase<T>
    {
        public abstract T Build();
        public abstract BuilderBase<T> AddToRepository();
        
        public static implicit operator T(BuilderBase<T> builder)
        {
            return builder.Build();
        }
    }
    
    public class TestBuilder : BuilderBase<string>
    {
        public override string Build()
        {
            return "Built by Build()";
        }
        
        public override BuilderBase<string> AddToRepository()
        {
            return this;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string x = new TestBuilder().AddToRepository();
            Console.WriteLine(x);
        }
    }

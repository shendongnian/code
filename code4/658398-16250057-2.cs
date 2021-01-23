    // We could even simplify further to only have IElement and IChildElement...
    public interface IElement {}
    public interface IChildElement : IElement {}
    public interface IGrandchildElement : IChildElement {}
    
    public interface IFunction<in T, TResult> where T : IElement
    {
        TResult Evaluate(T x);
    }
    
    public class Foo : IFunction<IChildElement, double>,
                       IFunction<IGrandchildElement, double>
    {
        public double Evaluate(IChildElement x) { return 0; }
        public double Evaluate(IGrandchildElement x) { return 1; }
    }
    
    class Test
    {
        static TResult Evaluate<TResult>(IFunction<IChildElement, TResult> function)
        {
            return function.Evaluate(null);
        }
        
        static void Main()
        {
            Foo f = new Foo();
            double res1 = Evaluate(f);
            double res2 = Evaluate<double>(f);
        }
    }

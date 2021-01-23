    public abstract class A<T, TSelf> // TSelf name just to clarify here
        where TSelf : A<T, TSelf>, new()
    {
        public abstract List<T> GetResult();
        public static List<T> GetResults()
        {
            var foo = new TSelf();
            return foo.GetResult();
        }
    }
    public class B : A<String, B>
    {
        public override List<String> GetResult()
        {
            // Do something....
        }
    }

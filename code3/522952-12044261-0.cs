    public class TestClass
    {
        string X = "";
        TestClass Test;
 
        public TestClass()
        {
            this.CheckParameters(t=>t.X, t=>t.Test);
            //OR
            //this.CheckParameters(t => t.X)
            //    .CheckParameters(t => t.Test);
        } 
    }
    public static class SOExtension
    {
        public static T CheckParameters<T>(this T obj, params Func<T, object>[] fxns)
        {
            foreach (var f in fxns)
                if (f(obj) == null) throw new ArgumentNullException();
            return obj;
        }
    }

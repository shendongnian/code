    public class TestClass
    {
        string X = "";
        TestClass Test;
 
        public TestClass()
        {
             this.CheckNull(t=>t.X, t=>t.Test);
            //OR
            //this.CheckNull(t => t.X)
            //    .CheckNull(t => t.Test);
        } 
    }
    public static class SOExtension
    {
        public static T CheckNull<T>(this T obj, params Func<T, object>[] fxns)
        {
            foreach (var f in fxns)
                if (f(obj) == null) throw new ArgumentNullException();
            return obj;
        }
    }

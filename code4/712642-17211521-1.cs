    using System.Linq.Expressions;
    using System.Linq.Dynamic;
    // ...
    public class Settings
    {
        public int x;
    }
    public class Window
    {
        public object ExecuteOperation1(string a, string b, string c, Settings s)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", a, b, c, s.x);
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string strExpr = "o.ExecuteOperation1(\"a\", \"b\", \"c\", settings)";
            Window form = new Window();
            Settings s = new Settings();
            s.x = 42;
            Type retType = typeof(object);
            ParameterExpression[] paramExprs = new ParameterExpression[] { 
                Expression.Parameter(typeof(Window), "o"), 
                Expression.Parameter(typeof(Settings), "settings") };
            LambdaExpression Le = System.Linq.Dynamic.DynamicExpression.ParseLambda(
                paramExprs, retType, strExpr);
            Delegate compiledLe = Le.Compile();
            object result = compiledLe.DynamicInvoke(form, s);
            Console.WriteLine("Result is {0}", result.ToString());
        }
    }

    using System.Linq.Expressions;
    using System.Linq.Dynamic;
    // ...
    public class Window
    {
        public object ExecuteOperation1(string a, string b, string c)
        {
            Console.WriteLine("{0}, {1}, {2}", a, b, c);
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string strExpr = "o.ExecuteOperation1(\"a\", \"b\", \"c\")";
            Window form = new Window();
            Type retType = typeof(object);
            ParameterExpression[] paramExprs = new ParameterExpression[] { Expression.Parameter(typeof(Window), "o") };
            LambdaExpression Le = System.Linq.Dynamic.DynamicExpression.ParseLambda(paramExprs, retType, strExpr);
            Delegate compiledLe = Le.Compile();
            object result = compiledLe.DynamicInvoke(form);
            Console.WriteLine("Result is {0}", result.ToString());
        }
    }

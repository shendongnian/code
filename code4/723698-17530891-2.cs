    public class MyClass<T>
        where T: class
    {
        public string GetExpressionString(Expression<Func<T, bool>> exp)
        {
            return exp.Body.ToString();
        }
    }
    // call like this
    var myInstance = new MyClass<string>();
    myInstance.GetExpressionString(s => false);

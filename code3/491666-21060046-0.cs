    public static void Main()
    {
        MethodInfo staticMethodInfo = GetMethodInfo( () => SampleStaticMethod(0, null) );
        
        Console.WriteLine(staticMethodInfo.ToString());
    }
    //Method that is used to get MethodInfo from an expression with a static method call
    public static MethodInfo GetMethodInfo(Expression<Action> expression)
    {
        var member = expression.Body as MethodCallExpression;
        if (member != null)
            return member.Method;
        throw new ArgumentException("Expression is not a method", "expression");
    }
    public static string SampleStaticMethod(int a, string b)
    {
        return a.ToString() + b.ToLower();
    }

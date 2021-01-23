    public static void Main()
    {
        Express(str => str.Length);
        Console.ReadLine();
    }
    static void Express(Expression<Func<String, Int32>> expression)
    {
        // Outputs: PropertyExpression (Which is a form of member expression)
        Console.WriteLine(expression.Body.GetType()); 
        Console.ReadLine();
    }

    class Program
    {
      static void Main(string[] args)
      {
        int i = 1;
        int? iNullable = 1;
        object o = 1;
        int j = 2;
        ParameterExpression pe1 = Expression.Parameter(typeof(int));
        ParameterExpression pe2 = Expression.Parameter(typeof(int));
        //explicitly creating expression by calling Expression.Method works fine
        Expression call = Expression.Equal(pe1, pe2);
        var f = Expression.Lambda<Func<int, int, bool>>(call, pe1, pe2).Compile();
        Console.WriteLine(f(i, i));
        Console.WriteLine(f((int)iNullable, i));
        Console.WriteLine(f(i, (int)o));
        Console.WriteLine(f(i, j));
        //I want to use a dynamic Expression method instead of Expression.Equal
        //so that it could be substituted with Expression.GreaterThan etc.
        List<String> expressionMethod = new List<string>(){"Equal", "GreaterThan"};
        foreach (String s in expressionMethod) DynamicExpression(s, j, i); 
        Console.ReadKey();
      }
      static void DynamicExpression(String methodName, int n1, int n2)
      {
        ParameterExpression pe1 = Expression.Parameter(typeof(int));
        ParameterExpression pe2 = Expression.Parameter(typeof(int));
        //get the method
        MethodInfo method = typeof(Expression)
            .GetMethod(methodName,
             new[] { typeof(Expression), typeof(Expression) });
        //Invoke
        Expression dynamicExp = (Expression)method.Invoke(null, new object[] { pe1, pe2 });
        var f = Expression.Lambda<Func<int, int, bool>>(dynamicExp, pe1, pe2).Compile();
        Console.WriteLine("Result for " 
             + n1.ToString() + " " 
             + methodName + " " + n2.ToString() + ": " + f(n1, n2));
      }
    }

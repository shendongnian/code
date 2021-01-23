    public static void PrintPropertyNames<T>(params Expression<Func<T, object>>[] properties)
    {
        foreach (var p in properties)
        {
            var expression = (MemberExpression)((UnaryExpression)p.Body).Operand;
            string memberName = expression.Member.Name;
            Console.WriteLine(memberName);
        }
    }

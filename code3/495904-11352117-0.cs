    public static string ExpressionToString<T>(Expression<Func<T>> e)
    {
        var un = e.Body as BinaryExpression;
        if (un != null)
        {
            var left = un.Left.ToString();
            var leftEnd = left.Split('.').LastOrDefault();
            var right = un.Right.ToString();
            var rightEnd = right.Split('.').LastOrDefault();
            return e.Body.ToString().Replace(left, leftEnd).Replace(right, rightEnd);
        }
        return e.Body.ToString();
    }
    Console.WriteLine(ExpressionToString(() => iTwo * iTwo));
    //prints (iTwo * iTwo)

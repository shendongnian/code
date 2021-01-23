    public static string GetSqlExpression(Expression expression)
    {
        if (expression is BinaryExpression)
        {
            return string.Format("({0} {1} {2})",
                GetSqlExpression(((BinaryExpression)expression).Left),
                GetBinaryOperator((BinaryExpression)expression),
                GetSqlExpression(((BinaryExpression)expression).Right));
        }
        if (expression is MemberExpression)
        {
            MemberExpression member = (MemberExpression)expression;
            
            // it is somewhat naive to make a bool member into "Member = TRUE"
            // since the expression "Member == true" will turn into "(Member = TRUE) = TRUE"
            if (member.Type == typeof(bool))
            {
                return string.Format("([{0}] = TRUE)", member.Member.Name);
            }
            return string.Format("[{0}]", member.Member.Name);
        }
        if (expression is ConstantExpression)
        {
            ConstantExpression constant = (ConstantExpression)expression;
            
            // create a proper SQL representation for each type
            if (constant.Type == typeof(int) ||
                constant.Type == typeof(string))
            {
                return constant.Value.ToString();
            }
            
            if (constant.Type == typeof(bool))
            {
                return (bool)constant.Value ? "TRUE" : "FALSE";
            }
            throw new ArgumentException();
        }
        throw new ArgumentException();
    }
    public static string GetBinaryOperator(BinaryExpression expression)
    {
        switch (expression.NodeType)
        {
            case ExpressionType.Equal:
                return "=";
            case ExpressionType.NotEqual:
                return "<>";
            case ExpressionType.OrElse:
                return "OR";
            case ExpressionType.AndAlso:
                return "AND";
            case ExpressionType.LessThan:
                return "<";
            case ExpressionType.GreaterThan:
                return ">";
            default:
                throw new ArgumentException();
        }
    }

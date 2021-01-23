    public static void MapTo<TInput, TOutput>(this TInput input, TOutput output, Expression<Func<TInput, TOutput, bool>> expression)
            where TInput : class
            where TOutput : class
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            Stack<Expression> unhandeledExpressions = new Stack<Expression>();
            unhandeledExpressions.Push(expression.Body);
            while (unhandeledExpressions.Any())
            {
                Expression unhandeledExpression = unhandeledExpressions.Pop();
                switch (unhandeledExpression.NodeType)
                {
                    case ExpressionType.AndAlso:
                        {
                            BinaryExpression binaryExpression = (BinaryExpression)unhandeledExpression;
                            unhandeledExpressions.Push(binaryExpression.Left);
                            unhandeledExpressions.Push(binaryExpression.Right);
                        }
                        break;
                    case ExpressionType.Equal:
                        {
                            BinaryExpression binaryExpression = (BinaryExpression)unhandeledExpression;
                            MemberExpression leftArgumentExpression = binaryExpression.Left as MemberExpression;
                            MemberExpression rightArgumentExpression = binaryExpression.Right as MemberExpression;
                            if (leftArgumentExpression == null || rightArgumentExpression == null)
                                throw new InvalidOperationException("Can only map to member expressions");
                            output.GetType().GetProperty(leftArgumentExpression.Member.Name).SetValue(
                                output, input.GetType().GetProperty(rightArgumentExpression.Member.Name).GetValue(input, null), null);
                        }
                        break;
                    default:
                        throw new InvalidOperationException("Expression type not supported");
                }
            }
        }
    }

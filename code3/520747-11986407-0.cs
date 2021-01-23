    public static class ExpressionRewriter {
        /// <summary>
        /// Casts the param of an expression.
        /// </summary>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <param name="inExpr">The in expr.</param>
        /// <returns></returns>
        public static Expression<Func<TOut, bool>> CastParam<TIn, TOut>(Expression<Func<TIn, bool>> inExpr) {
            if (inExpr.NodeType == ExpressionType.Lambda &&
                inExpr.Parameters.Count > 0) {
    
                var inP = inExpr.Parameters[0];
                var outP = Expression.Parameter(typeof(TOut), inP.Name);
    
                var outBody = Rewrite<TIn, TOut>(
                    inExpr.Body,
                    expr => (expr is ParameterExpression) ? outP : expr
                );
                return Expression.Lambda<Func<TOut, bool>>(
                        outBody,
                        new ParameterExpression[] { outP });
            } else {
                throw new NotSupportedException();
            }
        }
    
        /// <summary>
        /// Rewrites the specified expression.
        /// </summary>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <param name="exp">The exp.</param>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        private static Expression Rewrite<TIn, TOut>(Expression exp, Func<Expression, Expression> c) {
            Expression clone = null;
            var be = exp as BinaryExpression;
            switch (exp.NodeType) {
                case ExpressionType.AndAlso:
                    clone = Expression.AndAlso(Rewrite<TIn, TOut>(be.Left, c), Rewrite<TIn, TOut>(be.Right, c), be.Method);
                    break;
                case ExpressionType.OrElse:
                    clone = Expression.OrElse(Rewrite<TIn, TOut>(be.Left, c), Rewrite<TIn, TOut>(be.Right, c), be.Method);
                    break;
                case ExpressionType.Equal:
                    clone = Expression.Equal(Rewrite<TIn, TOut>(be.Left, c), Rewrite<TIn, TOut>(be.Right, c), be.IsLiftedToNull, be.Method);
                    break;
                case ExpressionType.GreaterThan:
                    clone = Expression.GreaterThan(Rewrite<TIn, TOut>(be.Left, c), Rewrite<TIn, TOut>(be.Right, c), be.IsLiftedToNull, be.Method);
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    clone = Expression.GreaterThanOrEqual(Rewrite<TIn, TOut>(be.Left, c), Rewrite<TIn, TOut>(be.Right, c), be.IsLiftedToNull, be.Method);
                    break;
                case ExpressionType.LessThan:
                    clone = Expression.LessThan(Rewrite<TIn, TOut>(be.Left, c), Rewrite<TIn, TOut>(be.Right, c), be.IsLiftedToNull, be.Method);
                    break;
                case ExpressionType.LessThanOrEqual:
                    clone = Expression.LessThanOrEqual(Rewrite<TIn, TOut>(be.Left, c), Rewrite<TIn, TOut>(be.Right, c), be.IsLiftedToNull, be.Method);
                    break;
                case ExpressionType.NotEqual:
                    clone = Expression.NotEqual(Rewrite<TIn, TOut>(be.Left, c), Rewrite<TIn, TOut>(be.Right, c), be.IsLiftedToNull, be.Method);
                    break;
                case ExpressionType.Not:
                    var ue = exp as UnaryExpression;
                    clone = Expression.Not(Rewrite<TIn, TOut>(ue.Operand, c));
                    break;
                case ExpressionType.MemberAccess:
                    var me = exp as MemberExpression;
    
                    MemberInfo newMember = me.Member;
                    Type newType = newMember.DeclaringType;
                    if (newType == typeof(TIn)) {
                        newType = typeof(TOut);
                        MemberInfo[] members = newType.GetMember(me.Member.Name);
                        if (members.Length == 1) {
                            newMember = members[0];
                        } else {
                            throw new NotSupportedException();
                        }
                    }
                    clone = Expression.MakeMemberAccess(Rewrite<TIn, TOut>(me.Expression, c), newMember);
                    break;
                case ExpressionType.Constant:
                    var ce = exp as ConstantExpression;
                    clone = Expression.Constant(ce.Value);
                    break;
                case ExpressionType.Parameter:
                    var pe = exp as ParameterExpression;
                    Type peNewType = pe.Type;
                    if (peNewType == typeof(TIn)) {
                        peNewType = typeof(TOut);
                    }
                    clone = Expression.Parameter(peNewType, pe.Name);
                    break;
                case ExpressionType.Call:
                    MethodCallExpression mce = exp as MethodCallExpression;
                    if (mce.Arguments != null && mce.Arguments.Count > 0) {
                        List<Expression> expressionList = new List<Expression>();
                        foreach (Expression expression in mce.Arguments) {
                            expressionList.Add(Rewrite<TIn, TOut>(expression, c));
                        }
                        clone = Expression.Call(Rewrite<TIn, TOut>(mce.Object, c), mce.Method, expressionList.ToArray());
                    } else {
                        clone = Expression.Call(Rewrite<TIn, TOut>(mce.Object, c), mce.Method);
                    }
                    break;
                case ExpressionType.Invoke:
                    InvocationExpression ie = exp as InvocationExpression;
                    List<Expression> arguments = new List<Expression>();
                    foreach (Expression expression in ie.Arguments) {
                        arguments.Add(Rewrite<TIn, TOut>(expression, c));
                    }
                    clone = Rewrite<TIn, TOut>(ie.Expression, c);
                    //clone = Expression.Invoke(Rewrite<TIn, TOut>(ie.Expression, c), arguments);
                    break;
                case ExpressionType.Convert:
                    var ue2 = exp as UnaryExpression;
                    //clone = Expression.Not(Rewrite<TIn, TOut>(ue2.Operand, c));
                    clone = Expression.Convert(ue2.Operand, ue2.Type, ue2.Method);
                    break;
                default:
                    throw new NotImplementedException(exp.NodeType.ToString());
            }
            return c(clone);
        }
    }

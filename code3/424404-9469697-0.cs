        static MemberInfo MemberInfoCore(Expression body, ParameterExpression param)
        {
            if (body.NodeType == ExpressionType.MemberAccess)
            {
                var bodyMemberAccess = (MemberExpression)body;
                return bodyMemberAccess.Member;
            }
            else if (body.NodeType == ExpressionType.Call)
            {
                var bodyMemberAccess = (MethodCallExpression)body;
                return bodyMemberAccess.Method;
            }
            else throw new NotSupportedException();
        }
        public static MemberInfo MemberInfo<T1>(Expression<Func<T1>> memberSelectionExpression)
        {
            if (memberSelectionExpression == null) throw new ArgumentNullException("memberSelectionExpression");
            return MemberInfoCore(memberSelectionExpression.Body, null/*param*/);
        }

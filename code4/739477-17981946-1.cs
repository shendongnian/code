          protected override Expression VisitMember(MemberExpression m)
        {
            if (m.Expression != null
                && m.Expression.NodeType == ExpressionType.Parameter
                && m.Expression.Type == _param.Type && ((ParameterExpression)m.Expression).Name == _param.Name)
            {
                object newVal;
                if (m.Member is FieldInfo)
                    newVal = ((FieldInfo)m.Member).GetValue(_value);
                else if (m.Member is PropertyInfo)
                    newVal = ((PropertyInfo)m.Member).GetValue(_value, null);
                else
                    newVal = null;
                return Expression.Constant(newVal);
            }
            return base.VisitMember(m);
        }

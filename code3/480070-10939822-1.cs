    public class Parent
    {
        public Parent Set<TValue>(Expression<Func<Parent, TValue>> func, TValue value)
        {
            MemberExpression mex = func.Body as MemberExpression;
            if(mex == null) throw new ArgumentException();
            
            var pi = mex.Member as PropertyInfo;
            if(pi == null) throw new ArgumentException();
    
            object target = GetTarget(mex.Expression);
            pi.SetValue(target, value, null);
            return this;
        }
    
        private object GetTarget(Expression expr)
        {
            switch (expr.NodeType)
            {
                case ExpressionType.Parameter:
                    return this;
                case ExpressionType.MemberAccess:
                    MemberExpression mex = (MemberExpression)expr;
                    PropertyInfo pi = mex.Member as PropertyInfo;
                    if(pi == null) throw new ArgumentException();
                    object target = GetTarget(mex.Expression);
                    return pi.GetValue(target, null);
                default:
                    throw new InvalidOperationException();
            }
        }
    }

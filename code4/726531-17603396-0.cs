    public static class BindingExtensions
    {
        public static T Evaluate<T>(this BindingExpression bindingExpr)
        {
            Type resolvedType = bindingExpr.ResolvedSource.GetType();
            PropertyInfo prop = resolvedType.GetProperty(
                bindingExpr.ResolvedSourcePropertyName);
            return (T)prop.GetValue(bindingExpr.ResolvedSource);
        }
    }

    public static class ModelStateHelpers
        {
            public static bool IsValidFor<TModel, TProperty>(this TModel model,
                                                             System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression,
                                                             ModelStateDictionary modelState)
            {
                string name = ExpressionHelper.GetExpressionText(expression);
    
                return modelState.IsValidField(name);
            }
        }

    public static class ModelStateExtensions
    {
        public static void AddModelError<TModel, TProperty>(
            this ModelStateDictionary modelState, 
            Expression<Func<TModel, TProperty>> ex, 
            string message
        )
        {
            var key = ExpressionHelper.GetExpressionText(ex);
            modelState.AddModelError(key, message);
        }
    }

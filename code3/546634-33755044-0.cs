    public static class ModelStateExtensions
    {
        public static void AddModelError<TModel, TProperty>(this TModel source,        
                                                        Expression<Func<TModel, TProperty>> ex, 
                                                        string message,
                                                        ModelStateDictionary modelState)
        {
            var key = System.Web.Mvc.ExpressionHelper.GetExpressionText(ex);
            modelState.AddModelError(key, message);
        }
    }

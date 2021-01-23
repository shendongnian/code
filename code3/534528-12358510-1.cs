    public static MvcHtmlString MyHelper<TModel,object>(
        this HtmlHelper<TModel> helper, 
        Expression<Func<TModel,object>> expression) {
            var newExpression = expression.Body as NewExpression;
            TModel model = helper.ViewData.Model;
            
            foreach (MemberExpression a in newExpression.Arguments) {
                var propertyName = a.Member.Name;
                var propertyValue = model.GetType().GetProperty(propertyName).GetValue(model, null);
                Console.WriteLine("{0}: {1}", propertyName, propertyValue);
            }  
    }

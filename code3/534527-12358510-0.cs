    public static MvcHtmlString MyHelper<TModel,object>(
        this HtmlHelper<TModel> helper, 
        Expression<Func<TModel,object>> expression) {
            var newExpression = expression.Body as NewExpression;
            
            foreach (MemberExpression a in newExpression.Arguments) {
                var propertyName = a.Member.Name;
                var propertyValue = TModel.GetType().GetProperty(propertyName).GetValue(helper, null);
                Console.WriteLine("{0}: {1}", propertyName, propertyValue);
            }  
    }

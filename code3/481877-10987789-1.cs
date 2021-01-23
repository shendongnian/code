    foreach (var propertyInfo in editFields)
    {
        var expParam = Expression.Parameter(typeof(TModel)); // TModel is a generic parameter on this method
        var expProp = Expression.Property(expParam, propertyInfo);
        var expression = Expression.Lambda(expProp, expParam);
    
        var fieldHtml = (MvcHtmlString)typeof (HtmlHelpers)
            .GetMethod("EditFieldFor")
            .MakeGenericMethod(typeof (TModel), propertyInfo.PropertyType)
            .Invoke(null, new object[] {html, expression, null});
    
        editFormHtml.Append(fieldHtml);
    }

    public static IHtmlString DateTimePickerFor<TModel, TValue>(
        this HtmlHelper<TModel> helper,
        Expression<Func<TModel, TValue>> expression,
        
        // other input parameters as needed
    ) {
        // metadata gives you access to a variety of useful things, such as the
        // display name and required status
        var metadata = ModelMetadata.FromLambdaExpression( expression, helper.ViewData );
        string markup = ""; // markup for your input            
        var name = helper.NameFor( expression ); // getting the name
        return MvcHtmlString.Create( markup  );
    }

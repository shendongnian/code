    public static MvcHtmlString TagCloudFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression) where TProperty : IList<MyType> where TProperty : IList<MyOtherType>
    {
            var model = helper.ViewContext.ViewData.ModelMetadata.Model;
            TProperty collection = expression.Compile().Invoke(model);
            foreach( var item in collection ) {
                //do whatever you want
            }
    }

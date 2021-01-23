    public static MvcHtmlString TagCloudFor<TModel , TProperty>( this HtmlHelper<TModel> helper , Expression<Func<TModel , TProperty>> expression )
            where TProperty : IList<MyType>, IList<MyOtherType> {
            
            //grab model from view
            TModel model = (TModel)helper.ViewContext.ViewData.ModelMetadata.Model;
            //invoke model property via expression
            TProperty collection = expression.Compile().Invoke(model);
            //iterate through collection after casting as IEnumerable to remove ambiguousity
            foreach( var item in (System.Collections.IEnumerable)collection ) {
                //do whatever you want
            }
        }

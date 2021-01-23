    public static MvcHtmlString TagCloudFor<TModel , TItemType>( this HtmlHelper<TModel> helper , Expression<Func<TModel , IEnumerable<TItemType>>> expression ) 
    // optional --- Where TItemType : MyCommonInterface
     { 
     
            TModel model = (TModel)helper.ViewContext.ViewData.ModelMetadata.Model; 
            //invoke model property via expression 
            IEnumerable<TItemType> collection = expression.Compile().Invoke(model); 
     
            foreach( var item in collection ) { 
                //do whatever you want 
            } 
     
        } 

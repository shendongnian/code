    public static MvcHtmlString MakeTable<TModel, TValue>(this HtmlHelper<TModel> html, IEnumerable<TValue> table)
    {
        var modelMetaData = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(TValue));
        foreach (TValue row in table)
        {
            //write out table
        }
    }

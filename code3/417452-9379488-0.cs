    public static class Exts
    {
        private const string Input = @"<div><span>{0} : </span><input data-bind='value: {1}'></input></div>";
        private const string Display = @"<div><span>{0} : </span><span data-bind='text: {1}'></span></div>";
        private const string DatePicker = @"<div><span>{0} : </span><input data-bind='datepicker: {1}, datepickerOptions: {{  dateFormat: ""dd/mm/yy""}}' /></div>";
        public static MvcHtmlString TemplateFor<TModel>(Expression<Func<TModel, object>> expression, bool edit) where TModel : class  , new()
        {
            var data = new ViewDataDictionary<TModel>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, data);
            var typ = metadata.ModelType;
            var s = edit? Input: Display;
            if (typ == typeof(System.DateTime) ||typ == typeof(System.DateTime?))
            {
                s = edit ? DatePicker : Display;
            }
            return MvcHtmlString.Create(string.Format(s, metadata.GetDisplayName(), metadata.PropertyName));
        }
    }

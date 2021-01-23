    public class ConvertCommaDelimitedList<T> : CollectionModelBinder<T>
    {
        public override bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
       {
           var _queryName = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query)[bindingContext.ModelName];
            List<string> _model = new List<string>();
            if (!String.IsNullOrEmpty(_queryName))
                _model = _queryName.Split(',').ToList();
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
                bindingContext.Model = _model.ConvertAll(m => (T)converter.ConvertFromString(m));
            else
                bindingContext.Model = _model;
        
            return true;
        }
    }

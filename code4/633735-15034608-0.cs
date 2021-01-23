    public class RouteForm<TModel>
    {
        public HtmlHelper<TModel> HtmlHelper { get; private set; }
    
        public RouteForm(HtmlHelper<TModel> htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }
    
        public RouteForm<TModel> hidden<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return this;
        }
        public MvcHtmlString end()
        {
            return MvcHtmlString.Empty;
        }
    }

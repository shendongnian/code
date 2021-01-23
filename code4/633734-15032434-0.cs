    public static class HtmlHelperExtensions
    {
        public static RouteForm<TModel> form(this HtmlHelper helper, TModel model)
        {
            return new RouteForm<TModel>(helper);
        }
    }
    public class RouteForm<TModel>
    {
        public RouteForm<TModel> hidden(Expression<Func<TModel, TValue>> expression)
        {
        }        
        public MvcHtmlString end()
        {
        }
    }

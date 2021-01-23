     var filters = System.Web.Http.GlobalConfiguration.Configuration.Filters;
        		filters.Clear();
        		filters.Add(new ValidationActionFilterAttribute());
    public class ValidationActionFilterAttribute : FilterAttribute, IActionFilter, IFilter
    {
        ...
    }

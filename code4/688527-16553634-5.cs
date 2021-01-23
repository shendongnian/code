    public class ModelSearchApiController : ApiController
    {
        public List<Model> Get([ModelBinder(typeof(MySearchModelBinder))] SearchModel search)
        {
            return new List<Model>
            {
                new Model { PageIndex = search.PageIndex, PageSize = search.PageSize, Terms = search.Terms }
            };
        }
    }
    public class MySearchModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            SearchModel value = new SearchModel();
            value.Terms = new Dictionary<string,object>();
            foreach (var queryParams in actionContext.Request.GetQueryNameValuePairs())
            {
                if (queryParams.Key == "PageIndex")
                {
                    value.PageIndex = int.Parse(queryParams.Value);
                }
                else if (queryParams.Key == "PageSize")
                {
                    value.PageSize = int.Parse(queryParams.Value);
                }
                else if (queryParams.Key.StartsWith("Terms."))
                {
                    value.Terms.Add(queryParams.Key.Substring("Terms.".Length), queryParams.Value);
                }
            }
            bindingContext.Model = value;
            return true;
        }
    }

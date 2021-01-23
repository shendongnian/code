    public class MyController : EntitySetController<Poco, int>
    {
        public IQueryable<Poco> Get()
        {
            var result = _myBusinessLogic.Search(QueryOptions.Top.Value);
            RemoveQueryString(Request, "$top");
            return result.AsQueryable()
        }    
        // This method relies that code that looks for query strings uses the extension
        // method Request.GetQueryNameValuePairs that relies on cached implementation to 
        // not parse request uri again and again.
        public static void RemoveQueryString(HttpRequestMessage request, string name)
        {
            request.Properties[HttpPropertyKeys.RequestQueryNameValuePairsKey] = request.GetQueryNameValuePairs().Where(kvp => kvp.Key != name);
        }
    }

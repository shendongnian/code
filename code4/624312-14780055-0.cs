    public class FieldFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var fieldsParameter = actionExecutedContext.Request.GetQueryNameValuePairs().Where(kvp => kvp.Key == "fields");
            if (fieldsParameter.Count() == 1)
            {
                object response;
                object newResponse;
                if (actionExecutedContext.Response.TryGetContentValue(out response))
                {
                    string[] fields = fieldsParameter.First().Value.Split(',');
                    IEnumerable<object> collection = response as IEnumerable<object>;
                    if (collection != null)
                    {
                        newResponse = collection.Select(o => SelectFields(fields, o));
                    }
                    else
                    {
                        newResponse = SelectFields(fields, response);
                    }
                    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, newResponse);
                }
            }
        }
        private static Dictionary<string, object> SelectFields(string[] fields, object value)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (string field in fields)
            {
                result.Add(field, GetValue(field, value));
            }
            return result;
        }
        private static object GetValue(string indexer, object value)
        {
            string[] indexers = indexer.Split('.');
            foreach (string property in indexers)
            {
                PropertyInfo propertyInfo = value.GetType().GetProperty(property);
                if (propertyInfo == null)
                {
                    throw new Exception(String.Format("property '{0}' not found on type '{1}'", property, value.GetType()));
                }
                value = propertyInfo.GetValue(value);
                if (value == null)
                {
                    return null;
                }
            }
            return value;
        }
    }

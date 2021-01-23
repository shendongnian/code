    public class JsonFilterAttribute : ActionFilterAttribute
    {
        public string Parameter { get; set; }
        public Type JsonDataType { get; set; }
        public JsonSerializerSettings Settings { get; set; }
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Parameter == null)
            {
                throw new ArgumentNullException("Parameter");
            }
    
            if (JsonDataType == null)
            {
                throw new ArgumentNullException("JsonDataType");
            }
    
            if (filterContext.HttpContext.Request.ContentType.Contains("application/json"))
            {
                string inputContent;
                using (var reader = new StreamReader(filterContext.HttpContext.Request.InputStream))
                {
                    inputContent = reader.ReadToEnd();
                }
    
                var result = JsonConvert.DeserializeObject(inputContent, JsonDataType, Settings ?? new JsonSerializerSettings());
                filterContext.ActionParameters[Parameter] = result;
            }
        }
    }

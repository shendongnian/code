    public class ApiResult : ActionResult
    {
        public ApiResult(string apiUrl, string jsonData)
            : this(apiUrl, jsonData, "PUT")
        {
        }
    
        public ApiResult(string apiUrl, string jsonData, string method)
        {
            ApiUrl = apiUrl;
            JsonData = jsonData;
            Method = method;
        }
    
    
        public string ApiUrl { get; private set; }
        public string JsonData { get; private set; }
        public string Method { get; set; }
    
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            var contentType = "application/json";
            response.ContentType = contentType;
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = contentType;
                byte[] data = Encoding.Default.GetBytes(JsonData);
                byte[] result = client.UploadData(ApiUrl, Method, data);
                response.Write(Encoding.Default.GetString(result));
            }
        }
    }

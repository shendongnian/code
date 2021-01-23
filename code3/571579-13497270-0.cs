    public class CustomResourceInterceptor : ResourceInterceptor
    {
        protected override ResourceResponse OnRequest(ResourceRequest request)
        {
            request.Method = "POST";
            var bytes = "Appending some text to the request";
            request.AppendUploadBytes(bytes, (uint) bytes.Length);
            request.AppendExtraHeader("custom-header", "this is a custom header");
    
            return null;
        }
    }

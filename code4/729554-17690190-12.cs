    public class JsonResponse
    {
        public JsonResponse()
        {
        }
        public bool IsValid { get; set; }
        public bool IsAjaxRequestUnsupported { get; set; }
        public string RedirectTo { get; set; }
        public string CanonicalUrl { get; set; }
    }
    public class JsonResponse<T> : JsonResponse
    {
        public JsonResponse() : base()
        {
        }
        public T Data { get; set; }
    }

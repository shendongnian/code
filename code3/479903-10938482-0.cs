    public interface IKeyValueProvider
    {
        string GetValue(string key);
    }
    class RequestFormKeyValueProvider : IKeyValueProvider
    {
        public string GetValue(string key)
        {
            return HttpContext.Current.Request.Form[key];
        }
    }

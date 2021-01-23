    public class CookieValueProviderFactory : ValueProviderFactory
    {
        public class CookieValueProvider : IValueProvider
        {
            private readonly NameValueCollection _cookies;
     
            public CookieValueProvider(NameValueCollection cookies)
            {
                _cookies = cookies;
            }
     
            public bool ContainsPrefix(string prefix)
            {
                return _cookies.AllKeys.Any(x => x.Contains(prefix));
            }
     
            public ValueProviderResult GetValue(string key)
            {
                if (_cookies == null)
                {
                    return null;
                }
     
                var val = _cookies.GetValues(key) == null ? null : _cookies.GetValues(key).FirstOrDefault();
                return val != null
                           ? new ValueProviderResult(val, val, CultureInfo.CurrentCulture)
                           : null;
            }
        }
     
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new CookieValueProvider(controllerContext.HttpContext.Request.Cookies);
        }
    }

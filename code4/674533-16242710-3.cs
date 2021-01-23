    public class CookieHelper : ICookieHelper
    {
        private readonly HttpContextBase _httpContext;
        public CookieHelper(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }
        public void SetCookie(User user)
        {
            var cookie = new HttpCookie(Constants.ApiKey, user.UserId.ToString())
            {
                Expires = DateTime.UtcNow.AddDays(1)
            };
            _httpContext.Response.Cookies.Add(cookie);
        }
        public void RemoveCookie()
        {
            var cookie = _httpContext.Response.Cookies[Constants.ApiKey];
            if (cookie != null)
            {
                cookie.Expires = DateTime.UtcNow.AddDays(-1);
                _httpContext.Response.Cookies.Add(cookie);
            }
        }
        public Guid GetUserId()
        {
            var cookie = _httpContext.Request.Cookies[Constants.ApiKey];
            if (cookie != null && cookie.Value != null)
            {
                return Guid.Parse(cookie.Value);
            }
            return Guid.Empty;
        }
    }

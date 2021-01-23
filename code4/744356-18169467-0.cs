    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
        public class ValidateHttpAntiForgeryToken : RequestFilterAttribute
        {
            public override void Execute(IHttpRequest req, IHttpResponse res, object requestDto)
            {
               try
                {
                    if (IsAjaxRequest(req))
                        ValidateRequestHeader(req);
                    else
                        AntiForgery.Validate();
                  
                }
                catch (Exception ex)
                {
                    res.StatusCode = 403;
                    res.StatusDescription = ex.Message;
                }
            }
    
            private void ValidateRequestHeader(IHttpRequest req)
            {
                var cookie = req.Cookies.FirstOrDefault(c => c.Value.Name.Contains(AntiForgeryConfig.CookieName));
                if (cookie.Value == null)
                {
                    throw new HttpAntiForgeryException(String.Format("Missing {0} cookie", AntiForgeryConfig.CookieName));
                }
                IEnumerable<string> xXsrfHeaders = req.Headers.GetValues("__RequestVerificationToken");
                if (xXsrfHeaders == null || !xXsrfHeaders.Any())
                    throw new HttpAntiForgeryException("Missing X-XSRF-Token HTTP header");
                AntiForgery.Validate(cookie.Value.Value, xXsrfHeaders.FirstOrDefault());
                
            }
    
            private static bool IsAjaxRequest(IHttpRequest request)
            {
                IEnumerable<string> xRequestedWithHeaders = request.Headers.GetValues("X-Requested-With");
                if (xRequestedWithHeaders != null && xRequestedWithHeaders.Any())
                {
                    string headerValue = xRequestedWithHeaders.FirstOrDefault();
                    if (!String.IsNullOrEmpty(headerValue))
                    {
                        return String.Equals(headerValue, "XMLHttpRequest", StringComparison.OrdinalIgnoreCase);
                    }
                }
                return false;
            }
        }

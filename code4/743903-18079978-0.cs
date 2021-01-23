        public string MethodRequiringAuthorization()
        {
            HttpContext httpContext = HttpContext.Current;
            NameValueCollection headerList = httpContext.Request.Headers;
            var authorizationField = headerList.Get("Authorization");            
            return "{Message" + ":" + "You-accessed-this-message-with-authorization" + "}";
        }

    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using DevDefined.OAuth.Framework;
    public class WebApiOAuthContextBuilder : OAuthContextBuilderHelpers
    {
        public IOAuthContext FromHttpRequest(HttpRequestMessage request)
        {
            var context = new OAuthContext
                {
                    RawUri = CleanUri(request.RequestUri), 
                    Cookies = CollectCookies(request), 
                    Headers = ExtractHeaders(request), 
                    RequestMethod = request.Method.ToString()
                };
            if (request.Content != null)
            {
                var contentResult = request.Content.ReadAsByteArrayAsync();
                context.RawContent = contentResult.Result;
                try
                {
                    // the following line can result in a NullReferenceException
                    var contentType = request.Content.Headers.ContentType.MediaType;
                    context.RawContentType = contentType;
                
                    if (contentType.ToLower().Contains("application/x-www-form-urlencoded"))
                    {
                        var stringContentResult = request.Content.ReadAsStringAsync();
                        context.FormEncodedParameters = HttpUtility.ParseQueryString(stringContentResult.Result);
                    }
                }
                catch (NullReferenceException)
                {
                }
            }
            ParseAuthorizationHeader(context.Headers, context);
            return context;
        }
        protected static NameValueCollection CollectCookies(HttpRequestMessage request)
        {
            IEnumerable<string> values;
            if (!request.Headers.TryGetValues("Set-Cookie", out values))
            {
                return new NameValueCollection();
            }
            var header = values.FirstOrDefault();
            return CollectCookiesFromHeaderString(header);
        }
        protected static NameValueCollection ExtractHeaders(HttpRequestMessage request)
        {
            var result = new NameValueCollection();
            foreach (var header in request.Headers)
            {
                var values = header.Value.ToArray();
                var value = string.Empty;
                if (values.Length > 0)
                {
                    value = values[0];
                }
                result.Add(header.Key, value);
            }
            return result;
        }
    }

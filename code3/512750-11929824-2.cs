    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using DevDefined.OAuth.Framework;
	
	public class WebApiOAuthContextBuilder : OAuthContextBuilder
    {
        public WebApiOAuthContextBuilder()
            : base(UriAdjuster)
        {
        }
        public IOAuthContext FromHttpRequest(HttpRequestMessage request)
        {
            var context = new OAuthContext
                {
                    RawUri = this.CleanUri(request.RequestUri), 
                    Cookies = this.CollectCookies(request), 
                    Headers = ExtractHeaders(request), 
                    RequestMethod = request.Method.ToString(), 
                    QueryParameters = request.GetQueryNameValuePairs()
                        .ToNameValueCollection(), 
                };
            if (request.Content != null)
            {
                var contentResult = request.Content.ReadAsByteArrayAsync();
                context.RawContent = contentResult.Result;
                try
                {
                    // the following line can result in a NullReferenceException
                    var contentType = 
                        request.Content.Headers.ContentType.MediaType;
                    context.RawContentType = contentType;
                    if (contentType.ToLower()
                        .Contains("application/x-www-form-urlencoded"))
                    {
                        var stringContentResult = request.Content
                            .ReadAsStringAsync();
                        context.FormEncodedParameters = 
                            HttpUtility.ParseQueryString(stringContentResult.Result);
                    }
                }
                catch (NullReferenceException)
                {
                }
            }
            this.ParseAuthorizationHeader(context.Headers, context);
            return context;
        }
        protected static NameValueCollection ExtractHeaders(
            HttpRequestMessage request)
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
        protected NameValueCollection CollectCookies(
            HttpRequestMessage request)
        {
            IEnumerable<string> values;
            if (!request.Headers.TryGetValues("Set-Cookie", out values))
            {
                return new NameValueCollection();
            }
            var header = values.FirstOrDefault();
            return this.CollectCookiesFromHeaderString(header);
        }
		
		/// <summary>
        /// Adjust the URI to match the RFC specification (no query string!!).
        /// </summary>
        /// <param name="uri">
        /// The original URI. 
        /// </param>
        /// <returns>
        /// The adjusted URI. 
        /// </returns>
        private static Uri UriAdjuster(Uri uri)
        {
            return
                new Uri(
                    string.Format(
                        "{0}://{1}{2}{3}", 
                        uri.Scheme, 
                        uri.Host, 
                        uri.IsDefaultPort ?
                            string.Empty :
                            string.Format(":{0}", uri.Port), 
                        uri.AbsolutePath));
        }
    }

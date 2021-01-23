    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    
    namespace MvcApplication1.Controllers
    {
        public class SessionController : ApiController
        {
            /// <summary>
            /// Saves specified the session data.
            /// </summary>
            /// <returns>
            /// A <see cref="HttpResponseMessage"/> that represents the response to the requested operation.
            /// </returns>
            [HttpPost()]
            public HttpResponseMessage SaveSession()
            {
                // Ensure content is form-url-encoded
                if(!IsFormUrlEncodedContent(this.Request.Content))
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest);
                }
    
                // Read content as a collection of key value pairs
                foreach (var parameter in ReadAsFormUrlEncodedContentAsync(this.Request.Content).Result)
                {
                    var key     = parameter.Key;
                    var value   = parameter.Value;
    
                    if(!String.IsNullOrEmpty(key))
                    {
                        // Do some work to persist session data here
                    }
                }
    
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
    
            /// <summary>
            /// Determines whether the specified content is form URL encoded content.
            /// </summary>
            /// <param name="content">
            /// The type that the <see cref="IsFormUrlEncodedContent(HttpContent)"/> method operates on.
            /// </param>
            /// <returns>
            /// <see langword="true"/> if the specified content is form URL encoded content; otherwise, <see langword="false"/>.
            /// </returns>
            public static bool IsFormUrlEncodedContent(HttpContent content)
            {
                if (content == null || content.Headers == null)
                {
                    return false;
                }
    
                return String.Equals(
                    content.Headers.ContentType.MediaType, 
                    FormUrlEncodedMediaTypeFormatter.DefaultMediaType.MediaType, 
                    StringComparison.OrdinalIgnoreCase
                );
            }
    
            /// <summary>
            /// Write the HTTP content to a collection of name/value pairs as an asynchronous operation.
            /// </summary>
            /// <param name="content">
            /// The type that the <see cref="ReadAsFormUrlEncodedContentAsync(HttpContent)"/> method operates on.
            /// </param>
            /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
            /// <remarks>
            /// The <see cref="ReadAsFormUrlEncodedContentAsync(HttpContent, CancellationToken)"/> method 
            /// uses the <see cref="Encoding.UTF8"/> format (or the character encoding of the document, if specified) 
            /// to parse the content. URL-encoded characters are decoded and multiple occurrences of the same form 
            /// parameter are listed as a single entry with a comma separating each value.
            /// </remarks>
            public static Task<IEnumerable<KeyValuePair<string, string>>> ReadAsFormUrlEncodedContentAsync(HttpContent content)
            {
                return ReadAsFormUrlEncodedContentAsync(content, CancellationToken.None);
            }
    
            /// <summary>
            /// Write the HTTP content to a collection of name/value pairs as an asynchronous operation.
            /// </summary>
            /// <param name="content">
            /// The type that the <see cref="ReadAsFormUrlEncodedContentAsync(HttpContent, CancellationToken)"/> method operates on.
            /// </param>
            /// <param name="cancellationToken">
            /// The cancellation token used to propagate notification that the operation should be canceled.
            /// </param>
            /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
            /// <remarks>
            /// The <see cref="ReadAsFormUrlEncodedContentAsync(HttpContent, CancellationToken)"/> method 
            /// uses the <see cref="Encoding.UTF8"/> format (or the character encoding of the document, if specified) 
            /// to parse the content. URL-encoded characters are decoded and multiple occurrences of the same form 
            /// parameter are listed as a single entry with a comma separating each value.
            /// </remarks>
            public static Task<IEnumerable<KeyValuePair<string, string>>> ReadAsFormUrlEncodedContentAsync(HttpContent content, CancellationToken cancellationToken)
            {
                return Task.Factory.StartNew<IEnumerable<KeyValuePair<string, string>>>(
                    (object state) =>
                    {
                        var result  = new List<KeyValuePair<string, string>>();
    
                        var httpContent = state as HttpContent;
    
                        if (httpContent != null)
                        {
                            var encoding    = Encoding.UTF8;
                            var charSet     = httpContent.Headers.ContentType.CharSet;
    
                            if (!String.IsNullOrEmpty(charSet))
                            {
                                try
                                {
                                    encoding    = Encoding.GetEncoding(charSet);
                                }
                                catch (ArgumentException)
                                {
                                    encoding    = Encoding.UTF8;
                                }
                            }
    
                            NameValueCollection parameters = null;
    
                            using (var reader = new StreamReader(httpContent.ReadAsStreamAsync().Result, encoding))
                            {
                                parameters = HttpUtility.ParseQueryString(reader.ReadToEnd(), encoding);
                            }
    
                            if (parameters != null)
                            {
                                foreach(var key in parameters.AllKeys)
                                {
                                    result.Add(
                                        new KeyValuePair<string, string>(key, parameters[key])
                                    );
                                }
                            }
                        }
    
                        return result;
                    },
                    content,
                    cancellationToken
                );
            }
        }
    }

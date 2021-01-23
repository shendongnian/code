        public class ContentTypeHandler : DelegatingHandler
        {
            /** Check that this is an IE browser. */
            if ((request.Headers.UserAgent.ToString().IndexOf("MSIE", System.StringComparison.Ordinal) > -1))
            {
                MediaTypeHeaderValue contentTypeValue;
                if (MediaTypeHeaderValue.TryParse("application/json", out contentTypeValue))
                {
                    request.Content.Headers.ContentType = contentTypeValue;
                    request.Content.Headers.ContentType.CharSet = "utf-8";
                }
            }
            /** Return request to flow. */
            return base.SendAsync(request, cancellationToken)
               .ContinueWith(task =>
               {
                    // work on the response
                    var response = task.Result;
                    return response;
               });
        }

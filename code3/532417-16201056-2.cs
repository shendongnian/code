    public class LoggingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log the request information
            LogRequestLoggingInfo(request);
     
            // Execute the request
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                // Extract the response logging info then persist the information
                LogResponseLoggingInfo(response);
                return response;
            });
        }
     
        private void LogRequestLoggingInfo(HttpRequestMessage request)
        {
            if (request.Content != null)
            {
                request.Content.ReadAsByteArrayAsync()
                    .ContinueWith(task =>
                        {
                            var result = Encoding.UTF8.GetString(task.Result);
                            // Log it somewhere
                        }).Wait(); // !!! Here is the fix !!!
            }
        }
     
        private void LogResponseLoggingInfo(HttpResponseMessage response)
        {
            if (response.Content != null)
            {
                response.Content.ReadAsByteArrayAsync()
                    .ContinueWith(task =>
                    {
                        var responseMsg = Encoding.UTF8.GetString(task.Result);
                        // Log it somewhere
                    });
            }
        }
    }

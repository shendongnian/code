    public static Task<HttpWebResponse> GetHttpResponseAsync(this HttpWebRequest request)
            {
                try
                {
                    return Task.Factory.FromAsync<HttpWebResponse>(request.BeginGetResponse, ar => (HttpWebResponse)request.EndGetResponse(ar), null);
                }
                catch (Exception ex)
                {
                    return TaskAsyncHelper.FromError<HttpWebResponse>(ex);
                }
            }

    private void OnAuthCallback(HttpContextWrapper context, WebServerClient client)
    {
        try
        {
            IAuthorizationState authorizationState = client.ProcessUserAuthorization(context.Request);
            AccessToken accessToken = AccessTokenSerializer.Deserialize(authorizationState.AccessToken);
            String username = accessToken.User;
            context.Items[USERNAME] = username;
        }
        catch (ProtocolException e)
        {
            if (e.InnerException != null)
            {
                String message = e.InnerException.Message;
                if (e.InnerException is WebException)
                {
                    WebException exception = (WebException)e.InnerException;
                    message = ExtractResponseString(webException);
                }
                EventLog.WriteEntry("OAuth Client", message);
            }
        }
    }
    public static string ExtractResponseString(WebException webException)
    {
        if (webException == null || webException.Response == null)
            return null;
        var responseStream = 
            webException.Response.GetResponseStream() as MemoryStream;
        if (responseStream == null)
            return null;
        var responseBytes = responseStream.ToArray();
        var responseString = Encoding.UTF8.GetString(responseBytes);
        return responseString;
    }

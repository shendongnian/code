    /// <summary>
    ///     Tries to rethrow the WebException with the data from the body included, if possible. 
    ///     Otherwise just rethrows the original message.
    /// </summary>
    /// <param name="wex">The web exception.</param>
    /// <exception cref="WebException"></exception>
    /// <remarks>
    ///     By default, on protocol errors, the body is not included in web exceptions. 
    ///     This solutions includes potentially relevant information for resolving the
    ///     issue.
    /// </remarks>
    private void ThrowWithBody(WebException wex) {
        if (wex.Status == WebExceptionStatus.ProtocolError) {
            string responseBody;
            try {
                //Get the message body for rethrow with body included
                responseBody = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
    
            } catch (Exception) {
                //In case of failure to get the body just rethrow the original web exception.
                throw wex;
            }
    
            //include the body in the message
            throw new WebException(wex.Message + $" Response body: '{responseBody}'", wex, wex.Status, wex.Response);
        }
    
        //In case of non-protocol errors no body is available anyway, so just rethrow the original web exception.
        throw wex;
    }

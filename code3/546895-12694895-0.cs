    catch (WebException webEx) {
        StringBuilder sb = new StringBuilder();
    
        sb.AppendLine(webEx.Message);
    
        sb.AppendLine();
        sb.AppendLine("REQUEST: ");
        sb.AppendLine();
    
        sb.AppendLine(string.Format("Request URL: {0} {1}", webRequest.Method, webRequest.Address));
        sb.AppendLine("Headers:");
        foreach (string header in webRequest.Headers) {
            sb.AppendLine(header + ": " + webRequest.Headers[header]);
        }
    
        sb.AppendLine();
        sb.AppendLine("RESPONSE: ");
        sb.AppendLine();
    
        sb.AppendLine(string.Format("Status: {0}", webEx.Status));
    
        if (null != webEx.Response) {
            HttpWebResponse response = (HttpWebResponse) webEx.Response;
    
            sb.AppendLine("Status Code: " + response.StatusCode);
            sb.AppendLine("Status Description: " + response.StatusDescription);
            if (0 != webEx.Response.ContentLength) {
                using (var stream = webEx.Response.GetResponseStream()) {
                    if (null != stream) {
                        using (var reader = new StreamReader(stream)) {
                            sb.AppendLine(string.Format("Response: {0}", reader.ReadToEnd()));
                        }
                    }
                }
            }
        }
    
        _log.Warn(sb.ToString(), webEx);
    
        throw new Exception(webEx.Message, webEx);
    }

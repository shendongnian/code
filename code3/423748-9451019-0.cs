        try
        {
            using (WebResponse response = request.GetResponse())
            {
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string result = reader.ReadToEnd();
                    if(result.StartsWith("NUMBER NOT IN LIST"))
                    {
                        return "Number Not In List";
                    }
                    return result;
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return statusCode = HttpStatusCode.Unauthorized.ToString();
                }
                else if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    return statusCode = HttpStatusCode.BadRequest.ToString();
                }
            }
        }

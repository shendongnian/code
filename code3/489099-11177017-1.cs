    WebResponse response = request.GetResponse();
    // Check the status. If it's not OK then don't bother with trying to parse the result
    if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
    {
        // Get the stream containing content returned by the server.
        Stream dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();
    
        JavaScriptSerializer jss = new JavaScriptSerializer();
        YahooResponse yr = jss.Deserialize<YahooResponse>(responseFromServer);
    
        // You may not want such strict checking; if not, remove the "NO ERROR" check
        if (yr.ResultSet.Error == 0 && yr.ResultSet.ErrorMessage.ToUpper() == "NO ERROR" && yr.ResultSet.Found > 0)
        {
            // inside here is where you can do whatever you need to.
            // ex. 1 - get the first result
            Result result = yr.ResultSet.results[0];
            
            // ex. 2 - loop through results
            foreach (Result r in yr.ResultSet.results)
            {
                // add values to a List<T> or something useful
            }
        }
    }
    
    // always do this as a matter of good practice
    response.Close();

    string url = "https://graph.facebook.com/cocacola";
    WebClient client = new WebClient();
    string jsonData = string.Empty;
    
    // Load the Facebook page info
    Console.WriteLine("Connecting to Facebook...");
    using (Stream data = client.OpenRead(url))
    {
        using (StreamReader reader = new StreamReader(data))
        {
            jsonData = reader.ReadToEnd();
        }
    }
    // Get number of likes from Json data
    JObject jsonParsed = JObject.Parse(jsonData);
    int likes = (int)jsonParsed.SelectToken("likes");
    
    // Write out the result
    Console.WriteLine("Number of Likes: " + likes);

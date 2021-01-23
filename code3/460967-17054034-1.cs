    using System.IO;
    using System.Net;
    static void sendParam()
    {
        // Initialise new WebClient object to send request
        var client = new WebClient();
        // Add the QueryString parameters as Name Value Collections
        // that need to go with the HTTP request, the data being sent
        client.QueryString.Add("id", "1");
        client.QueryString.Add("author", "Amin Malakoti Khah");
        client.QueryString.Add("tag", "Programming");
        // Prepare the URL to send the request to
        string url = "http://026sms.ir/getparam.aspx";
        // Send the request and read the response
        var stream = client.OpenRead(url);
        var reader = new StreamReader(stream);
        var response = reader.ReadToEnd().Trim();
        // Clean up the stream and HTTP connection
        stream.Close();
        reader.Close();
    }

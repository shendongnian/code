    string data = "<iOSDevice>xml_goes_here</iOSDevice>";
    using (WebClient client = new WebClient())
    {
        // That's the important part that you are missing in your request
        client.Headers[HttpRequestHeader.ContentType] = "text/xml";
        var result = client.UploadString(url, "PUT", data);
    }

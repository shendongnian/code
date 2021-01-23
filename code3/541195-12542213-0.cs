    StringBuilder sb = ... the data to send
    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "data", sb.ToString() }
        };
        byte[] result = client.UploadValues("http://report.hostname2.com/Pdf", values);
    }

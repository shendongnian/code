    using (var client = new WebClient())
    {
        var values = new NameValueCollection();
        // add values...
        client.UploadValuesAsync(new System.Uri(rawUrl), "POST", values);
    }

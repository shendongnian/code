    var uri = new Uri("http://localhost/Test/SaveImage");
    var nameValueCollection = new NameValueCollection();
    nameValueCollection.Add("ImageBytes", Convert.ToBase64String(data));
    WebClient web = new WebClient();
    web.UploadValuesAsync(uri, "Post", nameValueCollection);
    web.OnUploadValuesCompleted += ...

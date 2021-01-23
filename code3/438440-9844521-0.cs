    var client = new WebClient();
    client.Headers[HttpRequestHeader.ContentType] = "application/json";
    Task<String> task1 = Task.Factory.StartNew(() => {
        client.UploadString("http://localhost:45868/Product/GetAvailableProductsByContact",
                                             jsonser1);
    });

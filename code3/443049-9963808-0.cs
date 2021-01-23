    var client = new WebClient();
    client.OpenReadCompleted += (sender, e) =>
    {
        doc.Load(e.Result, Encoding.GetEncoding("iso-8859-7"));
        e.Result.Close();
    };
    client.OpenReadAsync(url);

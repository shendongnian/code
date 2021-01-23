    using (var stream = new MemoryStream())
    {
        var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
        context.Request.InputStream.Seek(0, SeekOrigin.Begin);
        context.Request.InputStream.CopyTo(stream);
        string requestBody = Encoding.UTF8.GetString(stream.ToArray());
    }

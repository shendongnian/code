    var response = await httpclient.GetAsync(urisource);
    if (checkencoding)
    {
        var contenttype = response.Content.Headers.First(h => h.Key.Equals("Content-Type"));
        var rawencoding = contenttype.Value.First();
        if (rawencoding.Contains("utf8") || rawencoding.Contains("UTF-8"))
        {
            var bytes = await response.Content.ReadAsByteArrayAsync();
            return Encoding.UTF8.GetString(bytes);
        }
    }

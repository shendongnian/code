    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
----------
    if (response.Content == null)
    {
        response.Content = new StringContent("");
        // The media type for the StringContent created defaults to text/plain.
    }

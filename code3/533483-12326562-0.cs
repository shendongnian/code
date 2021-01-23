    string contentType = (c.ResponseHeaders[HttpRequestHeader.ContentType] ?? "").ToLower();
    switch(contentType)
    {
        case "application/pdf":
            // Run PDF
            break;
        case "text/plain":
            // Text file
            break;
        // etc ...
    }

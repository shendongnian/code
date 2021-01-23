    public override Task WriteToStreamAsync(
        Type type, 
        object value,
        Stream stream,
        HttpContent content,
        TransportContext transportContext
    )
    {
        if (string.IsNullOrEmpty(JsonpCallbackFunction))
        {
            return base.WriteToStreamAsync(type, value, stream, content, transportContext);
        }
        // write the JSONP pre-amble
        var preamble = Encoding.ASCII.GetBytes(JsonpCallbackFunction + "(");
        stream.Write(preamble, 0, preamble.Length);
        return base.WriteToStreamAsync(type, value, stream, content, transportContext).ContinueWith((innerTask, state) =>
        {
            if (innerTask.Status == TaskStatus.RanToCompletion)
            {
                // write the JSONP suffix
                var responseStream = (Stream)state;
                var suffix = Encoding.ASCII.GetBytes(")");
                responseStream.Write(suffix, 0, suffix.Length);
            }
        }, stream, TaskContinuationOptions.ExecuteSynchronously);
    }

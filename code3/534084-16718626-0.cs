    public class CompressedRequestHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (IsRequetCompressed(request))
            {
                request.Content = DecompressRequestContent(request);
            }
            return base.SendAsync(request, cancellationToken);
        }
        private bool IsRequetCompressed(HttpRequestMessage request)
        {
            if (request.Content.Headers.ContentEncoding != null &&
                request.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                return true;
            }
            return false;
        }
        private HttpContent DecompressRequestContent(HttpRequestMessage request)
        {
            // Read in the input stream, then decompress in to the outputstream.
            // Doing this asynronously, but not really required at this point
            // since we end up waiting on it right after this.
            Stream outputStream = new MemoryStream();
            Task task = request.Content.ReadAsStreamAsync().ContinueWith(t =>
                {
                    Stream inputStream = t.Result;
                    var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress);
                    gzipStream.CopyTo(outputStream);
                    gzipStream.Dispose();
                    outputStream.Seek(0, SeekOrigin.Begin);
                });
            // Wait for inputstream and decompression to complete. Would be nice
            // to not block here and work async when ready instead, but I couldn't 
            // figure out how to do it in context of a DelegatingHandler.
            task.Wait();
            // Save the original content
            HttpContent origContent = request.Content;
            // Replace request content with the newly decompressed stream
            HttpContent newContent = new StreamContent(outputStream);
            // Copy all headers from original content in to new one
            foreach (var header in origContent.Headers)
            {
                newContent.Headers.Add(header.Key, header.Value);
            }
            return newContent;
        }

            var provider = new MultipartMemoryStreamProvider();
            var task = request.Content.ReadAsMultipartAsync(provider).
                 ContinueWith(o =>
                     {
                         //Select the appropriate content item this assumes only 1 part
                         var fileContent = provider.Contents.SingleOrDefault();
                         if (fileContent != null)
                         {
                             var fileName = fileContent.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                         }
                     }

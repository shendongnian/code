            var provider = new MultipartMemoryStreamProvider();
            var task = request.Content.ReadAsMultipartAsync(provider).
                 ContinueWith(o =>
                     {
                         var fileNameContent = provider.Contents.SingleOrDefault(
                             pc =>
                             pc.Headers.ContentDisposition.Name.Equals("\"POSTFILE\"",
                                                                       StringComparison.CurrentCultureIgnoreCase));
                         if (fileNameContent != null)
                         {
                             var fileName = fileNameContent.Headers.ContentDisposition.FileName.Replace("\"", "");
                         }
                     }

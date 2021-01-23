    if (Request.Content.IsMimeMultipartContent())
    {              
       var streamProvider = new MultipartMemoryStreamProvider();
       var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
       {
         foreach (var item in streamProvider.Contents)
         {
           //do something
         }
    });

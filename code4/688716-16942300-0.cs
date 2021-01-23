    using (HttpClient httpClient = new HttpClient())
    using (var multiPartContent = new MultipartFormDataContent())
    {
         httpClient.BaseAddress = new Uri(BaseAddress);
         var fileContent = new ByteArrayContent(*filebytes*);
         //Create content header
         fileContent.Headers.ContentDisposition = new ontentDispositionHeaderValue("attachment")
                    {
                        FileName = *fileName*
                    };
           //Add file to the multipart request
           multiPartContent.Add(fileContent);
           //Add any other file?
           ...
          //Post it
          HttpResponseMessage response = await httpClient.PostAsync("hostURL", multiPartContent);
     }

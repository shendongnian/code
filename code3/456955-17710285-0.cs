    public static void SetFile(String serviceUrl, byte[] fileArray, String fileName)
    {
        try
        {
            using (var client = new HttpClient())
            {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var content = new MultipartFormDataContent())
                    {
                        var fileContent = new ByteArrayContent(fileArray);//(System.IO.File.ReadAllBytes(fileName));
                        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = fileName
                        };
                        content.Add(fileContent);
                        var result = client.PostAsync(serviceUrl, content).Result;
                    }
            }
        }
        catch (Exception e)
        {
            //Log the exception
        }
    }

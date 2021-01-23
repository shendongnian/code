    var client = new HttpClient();
                    client.BaseAddress = new Uri(BASE_URL);
                    var multipart = new MultipartFormDataContent();
    
                    foreach(var file in files)
                    {
                        var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(file.FullName));
                        multipart.Add(fileContent, "files", file.Name);
                    }
    
                   
                    return client.PostAsync("Images", multipart);

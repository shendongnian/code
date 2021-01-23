    HttpClient client = new HttpClient();
    MultipartFormDataContent form = new MultipartFormDataContent();
    FileInfo file = new FileInfo(@"<file path>");
    form.Add(new StreamContent(file.OpenRead()),"FileParam",file.Name);
    HttpResponseMessage response = await client.PostAsync("http://<host>:<port>/upload", form);
    Console.WriteLine(response.StatusCode);
    Console.WriteLine(response.ReasonPhrase);
    Console.WriteLine(response.ToString());
    Console.WriteLine(Encoding.ASCII.GetString(await response.Content.ReadAsByteArrayAsync()));

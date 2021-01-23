    using(var f = System.IO.File.OpenRead(@"F:\test.html"))
    {
          var client = new HttpClient();
          var content = new StreamContent(f);
          var mpcontent = new MultipartFormDataContent();
          content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
          mpcontent.Add(content);	
          await client.PostAsync("http://ya.ru", mpcontent);
    }

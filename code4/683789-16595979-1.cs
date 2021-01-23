    public static async Task<string> Upload(byte[] image)
    {
         using (var client = new HttpClient())
         {
             using (var content =
                 new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
             {
                 content.Add(new StreamContent(new MemoryStream(image)), "bilddatei", "upload.jpg");
    
                  using (
                     var message =
                         await client.PostAsync("http://www.directupload.net/index.php?mode=upload", content))
                  {
                      var input = await message.Content.ReadAsStringAsync();
    
                      return !string.IsNullOrWhiteSpace(input) ? Regex.Match(input, @"http://\w*\.directupload\.net/images/\d*/\w*\.[a-z]{3}").Value : null;
                  }
              }
         }
    }

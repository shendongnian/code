    public static async void DownloadImagesAsync(BitmapImage list, String Url)
    {
       try
       {
           HttpClient httpClient = new HttpClient();
           // Limit the max buffer size for the response so we don't get overwhelmed
           httpClient.MaxResponseContentBufferSize = 256000;
           httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE           10.0; Windows NT 6.2; WOW64; Trident/6.0)");
           HttpResponseMessage response = await httpClient.GetAsync(Url);
           response.EnsureSuccessStatusCode();
           byte[] str = await response.Content.ReadAsByteArrayAsync();
           InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
           DataWriter writer = new DataWriter(randomAccessStream.GetOutputStreamAt(0));
           writer.WriteBytes(str);
           await writer.StoreAsync();
           BitmapImage img = new BitmapImage();
           img.SetSource(randomAccessStream);
           //img.DecodePixelHeight = 92;
           img.DecodePixelWidth = 60; //specify only width, aspect ratio maintained
           list.ImageBitmap = img;                   
       }catch(Exception e){
          System.Diagnostics.Debug.WriteLine(ex.StackTrace);
       }
    }

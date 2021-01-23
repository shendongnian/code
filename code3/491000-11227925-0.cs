    private async Task<byte[]> DownloadImageFromWebsiteAsync(string url)
    {
      try
      {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        using (WebResponse response = await request.GetResponseAsync())
        using (var result = new MemoryStream())
        {
          await imageStream.CopyToAsync(result);
          return result.ToArray();
        }
      }
      catch (WebException ex)
      {
        return null;
      }
    }

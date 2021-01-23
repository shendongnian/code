    private static PushStreamContent CopyContentStream(HttpResponseMessage sourceContent)
    {
      Func<Stream, Task> copyStreamAsync = async stream =>
      {
        using (stream)
        using (var sourceStream = await sourceContent.Content.ReadAsStreamAsync())
        {
          await sourceStream.CopyToAsync(stream);
        }
      };
      var content = new PushStreamContent(stream => { var _ = copyStreamAsync(stream); });
      return content;
    }

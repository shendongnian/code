    private async Task<String> getRawPostData()
    {
        using (var contentStream = await this.Request.Content.ReadAsStreamAsync())
        {
            contentStream.Seek(0, SeekOrigin.Begin);
            using (var sr = new StreamReader(contentStream))
            {
                return sr.ReadToEnd();
            }
        }
    }

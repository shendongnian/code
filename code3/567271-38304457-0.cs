    using (var contentStream = await this.Request.Content.ReadAsStreamAsync())
    {
        contentStream.Seek(0, SeekOrigin.Begin);
        using (var sr = new StreamReader(contentStream))
        {
            string rawContent = sr.ReadToEnd();
            // use raw content here
        }
    }

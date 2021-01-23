    private async Task<string> DownloadHtml(string query)
    {
        using (var client = new WebClient())
        {
            try
            {
                return await client.DownloadStringTaskAsync(query);
            }
            catch (Exception ex)
            {
                Logger.Error(msg, ex);
                return null;
            }
        }
    }

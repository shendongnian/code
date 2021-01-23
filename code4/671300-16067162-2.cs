    private async Task<string> UpdateAsync()
    {
        try
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(url);     
            }
        }
        catch
        {
            return "Updation failed. Error code:vish42042";
        }
    }  

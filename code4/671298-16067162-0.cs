    private async Task update()
    {
        try
        {
            using (var client = new HttpClient())
            {
                rawdata = await client.GetStringAsync(url);     
            }
        }
        catch
        {
            rawdata = "Updation failed. Error code:vish42042";
        }
    }  

    public static async Task<object> PostCallAPI(string url, object jsonObject)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<object>(jsonString);
                }
            }
        }
        catch (Exception ex)
        {
            myCustomLogger.LogException(ex);
        }
        return null;
    }

    public async Task<T> getAsync(string url)
    {
        try
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<T>();
                return (T)result;
            }
            else
            {
                return null;
            }
        }
        catch (Newtonsoft.Json.JsonException ex)
        {
            Console.WriteLine(ex.ToString());
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.ToString());
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return null;
    }

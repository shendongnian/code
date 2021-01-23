    static async void dotest(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode.ToString());
            }
            else
            {
                // problems handling here
                Console.WriteLine(
                    "Error occurred, the status code is: {0}", 
                    response.StatusCode
                );
            }
        }
    }

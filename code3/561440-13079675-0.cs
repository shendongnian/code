            // Create a New HttpClient object.
            var handler = new HttpClientHandler {AllowAutoRedirect = false};
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("user-agent",
                                             "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();

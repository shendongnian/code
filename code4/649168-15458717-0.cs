            string searchResults = string.Empty;
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                HttpClient client = new HttpClient(handler);
                client.MaxResponseContentBufferSize = 100000;
                string responseString = await client.GetStringAsync(RestServiceUrl);
                searchResults = responseString;
            }
            catch (HttpRequestException e)
            {
                searchResults = e.Message;
            }

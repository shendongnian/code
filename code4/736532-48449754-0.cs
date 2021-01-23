        private async Task<byte[]> GetImageAsByteArray(string urlImage, string urlBase)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            var response = await client.GetAsync(urlImage);
            return await response.Content.ReadAsByteArrayAsync();
        }

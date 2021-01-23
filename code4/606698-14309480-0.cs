        public Band(String Name)
		{
            this.Name = Name;
		}
        public async Task Init()
        {
            await GetHtmlDocument();
            GenerateId();
            GetAlbumDocument();
            GenerateLogo();
            GeneratePhoto();
            CreateAlbumList();
        }
        // Note Task Return type
        private async Task GetHtmlDocument()
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler as HttpMessageHandler) { BaseAddress = new Uri(@"http://www.metal-archives.com/bands/" + Name) };
            var r = await client.GetAsync(client.BaseAddress);
            string html = null;
            if (r.IsSuccessStatusCode) html = await r.Content.ReadAsStringAsync();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            DocumentBand = document;
        }

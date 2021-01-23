    private async Task<string> GetFile()
    {
        using (var client = new HttpClient() { BaseAddress = new Uri("http://www.iddaa.com.tr") })
        {
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MOZILLA", "5.0"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("(WINDOWS NT 6.1; WOW64)"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("APPLEWEBKIT", "537.1"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("(KHTML, LIKE GECKO)"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("CHROME", "21.0.1180.75"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SAFARI", "537.1"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            var result = await client.GetAsync("/XML/IDDAAMACPROGRAMI/index.htm?iddaadrawid=12.09.2012&iddaadrawide=13.09.2012&foraccess=KSsec654");
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsStringAsync();
        }
    }

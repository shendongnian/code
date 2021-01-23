    if (response.IsSuccessStatusCode)
    {
        var info = response.Content.ReadAsStringAsync();
        JsonObject d = JsonValue.Parse(info.Result).GetObject();
        string id = d["d"].GetObject()["ListItemAllFields"].GetObject().GetNamedValue("ID").Stringify();
        client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
        client.BaseAddress = new System.Uri(url);
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Add("X-RequestDigest", digest);
        client.DefaultRequestHeaders.Add("X-HTTP-Method", "MERGE");
        client.DefaultRequestHeaders.Add("IF-MATCH", "*");
        HttpContent strContent = new StringContent(String.Concat("{ '__metadata': { 'type': 'SP.List' }, 'Title': '", filename, "' }"));
        strContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        strContent.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("odata", "verbose"));
        HttpResponseMessage updateResponse = await client.PostAsync(String.Concat("_api/web/lists/GetByTitle('Project Photos')/Items(", id, ")"), strContent);
        updateResponse.EnsureSuccessStatusCode();
        if (updateResponse.IsSuccessStatusCode)
        {
        }
    }

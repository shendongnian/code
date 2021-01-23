    public static async void CheckJson(object sender, object e)
    {
        var client = new HttpClient();
        client.MaxResponseContentBufferSize = 1024 * 1024;
        try
        {
            var response = await client.GetAsync(new Uri("URI"));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var jobj = JObject.Parse(result);
            var list = jobj.Children()
                .Cast<JProperty>()
                .Select(p => new ComponentGroup()
                {
                    Name = p.Name,
                    Type = (string)p.Value["P1"],
                    Value = (string)p.Value["P2"]
                })
                .ToList();
            // add this code
            if (!_componentcollection.Any())
                System.Diagnostics.Debugger.Break();
            _componentcollection = new ObservableCollection<ComponentGroup>(list);
        }
        catch (HttpRequestException ex)
        {
        }
    }

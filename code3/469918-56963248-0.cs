    HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get,"URL");
    msg.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
        
    HttpResponseMessage response = await _httpClient.SendAsync(msg);
    response.EnsureSuccessStatusCode();
        
    string json = await response.Content.ReadAsStringAsync();

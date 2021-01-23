    // GET api/values
    [HttpGet]
    public async Task<ActionResult<string>> getUseBearerAsync(string token, string baseUrl, string action)
    {
        var callApi = new CallApi(baseUrl);
        var client = callApi.getClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await client.GetAsync(action);
        if (response.IsSuccessStatusCode)
        {
            return Ok(await response.Content.ReadAsStringAsync());
        }
        else
            return NotFound();
    }

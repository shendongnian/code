    // GET api/values
    [HttpGet]
    public async Task<ActionResult<string>> postNoBearerAsync(string email, string password,string baseUrl, string action)
    {
        var request = new LoginRequest
        {
            email = email,
            password = password
        };
        var callApi = new CallApi(baseUrl);
        var client = callApi.getClient();
        HttpResponseMessage response = await client.PostAsJsonAsync(action, request);
        if (response.IsSuccessStatusCode)
            return Ok(await response.Content.ReadAsAsync<string>());
        else
            return NotFound();
    }

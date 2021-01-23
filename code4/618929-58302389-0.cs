     var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
              responseMessage = await response.Content.ReadAsAsync<ResponseMessage>();
        }

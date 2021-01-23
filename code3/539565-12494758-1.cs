    [HttpPut]
    public HttpResponseMessage Put(int accountId)
    {
        HttpContent requestContent = Request.Content;
        string jsonContent = requestContent.ReadAsStringAsync().Result;
        CONTACT contact = JsonConvert.DeserializeObject<CONTACT>(jsonContent);
        ...
    }

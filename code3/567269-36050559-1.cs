    [HttpPost]
    public async Task<string> Post()
    {
        string content;
        using (var sr = new StreamReader(Request.Body))
        {
           content = await sr.ReadToEndAsync();
        }
        return "SUCCESS";
    }

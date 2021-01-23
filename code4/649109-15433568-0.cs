    public JsonResult GetData()
    {
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        var item = new Item();
        item.GenerateData();
        return Json(item);
    }

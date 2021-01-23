    public async Task<ActionResult> ActionAsync()
    {
        
        var data = await GetDataAsync();
    
        return View(data);
    }
    
    private async Task<string> GetDataAsync()
    {
        // a very simple async method
        var result = await MyWebService.GetDataAsync();
        return result.ToString();
    }

    public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
        var builder = new ODataConventionModelBuilder();
        
        // This line will allow you to interpret all the metadata from your code first model
        builder.EntitySet<EfContext>("EfContext");
    
        var model = builder.GetEdmModel();
        var odataFormatters = ODataMediaTypeFormatters.Create(model);
        var delta = content.ReadAsAsync(type, odataFormatters).Result; 
    
        var tcs = new TaskCompletionSource<object>(); 
        tcs.SetResult(delta); 
        return tcs.Task; 
    }

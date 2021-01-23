    StreamSocket _client;
    
    private async Task Start() {
        await SomeMethod();
         SomeOtherMethod();
    }
    
    private async Task SomeMethod(string sample)
    {
        var request = new GetSampleRequestObject(sample);
        byte[] payload = ConvertToByteArray(request, Encoding.UTF8);
    
        DataWriter writer = new DataWriter(_client.OutputStream);
        writer.WriteBytes(payload);
        await writer.StoreAsync(); // <--- after this executes, it exits the method and continues
        await writer.FlushAsync(); // <--- breakpoint never reaches here, instead
        writer.DetachStream();
    }
    
    private void SomeOtherMethod()
    {
        string hello = "hello"; // <--- it skips everything and reaches here!
    }

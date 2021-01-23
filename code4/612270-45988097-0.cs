    private async Task SumPageSizesAsync()
    {
        // To use the HttpClient type in desktop apps, you must include a using directive and add a 
        // reference for the System.Net.Http namespace.
        HttpClient client = new HttpClient();
        // . . .
        Task<byte[]> getContentsTask = client.GetByteArrayAsync(url);
        byte[] urlContents = await getContentsTask;
    
        // Equivalently, now that you see how it works, you can write the same thing in a single line.
        //byte[] urlContents = await client.GetByteArrayAsync(url);
        // . . .
    }

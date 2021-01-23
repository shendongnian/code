    // create this in the constructor, stream manages can be reused
    // see details in this answer https://stackoverflow.com/a/42599288/185498
    var streamManager = new RecyclableMemoryStreamManager();
    using (var file = File.Open(destination, FileMode.Create))
    {
        using (var memoryStream = streamManager.GetStream()) // RecyclableMemoryStream will be returned, it inherits MemoryStream, however prevents data allocation into the LOH
        {
            using (var writer = new StreamWriter(memoryStream))
            {
                var serializer = JsonSerializer.CreateDefault();
                serializer.Serialize(writer, data);
                await writer.FlushAsync().ConfigureAwait(false);
                memoryStream.Seek(0, SeekOrigin.Begin);
                await memoryStream.CopyToAsync(file).ConfigureAwait(false);
            }
        }
        await file.FlushAsync().ConfigureAwait(false);
    }

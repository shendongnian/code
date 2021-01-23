    using (var file = File.Open(destination, FileMode.Create))
    {
        using (var memoryStream = new MemoryStream())
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

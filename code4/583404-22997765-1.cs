    using (var memoryStream = new MemoryStream())
    {
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter))
        {
            csvWriter.WriteRecords<T>(records);
        } // StreamWriter gets flushed here.
        return memoryStream.ToArray();
    }

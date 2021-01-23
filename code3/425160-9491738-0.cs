    using (Stream stream = File.OpenRead(out))
    using (var reader = ZipReader.Open(stream))
    {
        while (reader.MoveToNextEntry())
        {
            if (!reader.Entry.IsDirectory)
            {
                using (Stream newStream = File.Create("123" + in))
                {
                    reader.WriteEntryTo(newStream);
                }
            }
        }
    }

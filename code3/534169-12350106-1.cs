    using (MemoryStream zipStream = new MemoryStream())
    {
        using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
        {
            var entry = zip.CreateEntry("test.txt");
            using (StreamWriter sw = new StreamWriter(entry.Open()))
            {
                sw.WriteLine(
                    "Etiam eros nunc, hendrerit nec malesuada vitae, pretium at ligula.");
            }
        }
        var file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(
            "test.zip",
            CreationCollisionOption.ReplaceExisting);
        zipStream.Position = 0;
        using (Stream s = await file.OpenStreamForWriteAsync())
        {
            zipStream.CopyTo(s);
        }
    }

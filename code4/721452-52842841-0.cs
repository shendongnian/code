    private static bool unrar(string filename)
    {
        bool error = false;
        string outputpath = Path.GetDirectoryName(filename);
        try
        {
            using (Stream stream = File.OpenRead(filename))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        Console.WriteLine(reader.Entry.Key);
                        reader.WriteEntryToDirectory(outputpath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed: " + e.Message);
            error = true;
        }
        if (!error)
        {
            File.Delete(filename);
        }
        return error;
    }

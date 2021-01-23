    ...
    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
    {
        fs.Seek(0, SeekOrigin.End);
        using (StreamWriter writer = new StreamWriter(fs))
        {
            // To append, update the stream's position to the end of the file
            writer.WriteLine("test");
        }
    }
    ...

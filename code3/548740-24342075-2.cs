    public string[] WriteSafeReadAllLines(String path)
    {
        using (var csv = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (var sr = new StreamReader(csv))
        {
            List<string> file = new List<string>();
            while (!sr.EndOfStream)
            {
                file.Add(sr.ReadLine());
            }
            return file.ToArray();
        }
    }

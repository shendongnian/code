    public static IEnumerable<string> EnumerateLines(string fileName)
    {
        using (
            var streamReader =
                new StreamReader(new FileStream(fileName,
                                                FileMode.Open,
                                                FileAccess.Read,
                                                FileShare.Read)))
        {
            while (true)
            {
                if (streamReader.EndOfStream)
                    yield break;
    
                Console.WriteLine("read another line...");
                yield return streamReader.ReadLine();
            }
        }
    }

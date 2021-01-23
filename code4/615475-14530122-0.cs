    private static void MultipleFilesToSingleFile(string dirPath, string filePattern, string destFile)
    {
        string[] fileAry = Directory.GetFiles(dirPath, filePattern);
        Console.WriteLine("Total File Count: {0}", fileAry.Length);
        using (var destStream = File.Create(destFile))
        {
            foreach (string filePath in fileAry)
            {
                using (var sourceStream = File.OpenRead(filePath))
                    sourceStream.CopyTo(destStream); // You can pass the buffer size as second argument.
                Console.WriteLine("File Processed: {0}", filePath);
            }
        }
    }

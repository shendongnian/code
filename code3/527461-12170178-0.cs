    void InsertACharacterNoStringAfterEveryNCharactersInAHugeTextFileUsingCSharp(
        string inputPath, string outputPath, int blockSize, string separator)
    {
        using (var input = File.OpenText(inputPath))
        using (var output = File.CreateText(outputPath))
        {
            var buffer = new char[blockSize];
            int readCount;
            while ((readCount = input.ReadBlock(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, readCount);
                if (readCount == buffer.Length)
                    output.Write(separator);
            }
        }
    }
    // usage:
    InsertACharacterNoStringAfterEveryNCharactersInAHugeTextFileUsingCSharp(
        inputPath, outputPath, 3, Environment.NewLine);

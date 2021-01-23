    public void SplitFiles(int[] newFiles, string inputFile)
    {
        string baseName = Path.GetFilenameWithoutExtension(inputFile);
        string extension = Path.GetExtension(inputFile);
        using (TextReader reader = File.OpenText(inputFile))
        {
            for (int i = 0; i < newFiles.Length; i++)
            {
                string outputFile = baseName + i + extension;
                // Could put this into the CopyLines method if you wanted
                if (File.Exists(outputFile))
                {
                    // Better than silently returning, I'd suggest...
                    throw new IOException("File already exists: " + outputFile);
                }
                CopyLines(reader, outputFile, newFiles[i]);
            }
        }
    }
    private static void CopyLines(TextReader reader, string outputFile, int count)
    {
        using (TextWriter writer = File.CreateText(outputFile))
        {
            for (int i = 0; i < count; i++)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    return; // Premature end of input
                }
                writer.WriteLine(line);
            }
        }
    }

    public void SplitFiles(int[] newFiles, string inputFile)
    {
        string baseName = Path.GetFilenameWithoutExtension(inputFile);
        string extension = Path.GetExtension(inputFile);
        using (TextReader reader = File.OpenText(inputFile))
        {
            for (int i = 0; i < newFiles.Length; i++)
            {
                string outputFile = baseName + i + extension;
                if (File.Exists(outputFile))
                {
                    // Better than silently returning, I'd suggest...
                    throw new IOException("File already exists: " + outputFile);
                }
                int linesToCopy = newFiles[i];
                using (TextWriter writer = File.CreateText(outputFile))
                {
                    for (int j = 0; i < linesToCopy; j++)
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
        }
    }

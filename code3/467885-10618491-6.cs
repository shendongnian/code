    public static void StripUnwantedLines(
        string inputFilePath,
        string outputFilePath,
        string lineToRemove)
    {
        using (StreamReader reader = new StreamReader(inputFilePath))
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                bool isUnwanted = String.Equals(line, lineToRemove,
                    StringComparison.CurrentCultureIgnoreCase);
                if (!isUnwanted)
                    writer.WriteLine(line);
            }
        }
    }

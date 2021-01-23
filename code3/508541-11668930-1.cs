    int splitSize = Convert.ToInt32(txtNoOfLines.Text);
    using (var lineIterator = File.ReadLines(...))
    {
        bool stillGoing = true;
        for (int chunk = 0; stillGoing; chunk++)
        {
            stillGoing = WriteChunk(lineIterator, splitSize, chunk);
        }
    }
    ...
    private static bool WriteChunk(IEnumerator<string> lineIterator,
                                   int splitSize, int chunk)
    {
        using (var writer = File.CreateText("file " + chunk + ".txt"))
        {
            for (int i = 0; i < splitSize; i++)
            {
                if (!lineIterator.MoveNext())
                {
                    return false;
                }
                writer.WriteLine(lineIterator.Current);
            }
        }
        return true;
    }

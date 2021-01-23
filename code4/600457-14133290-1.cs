    private static void WriteToDisk(string fileName, int[] vector)
    {
        WriteToDisk(fileName, vector, (w, o) => w.Write(o));
    }
    private static void WriteToDisk(string fileName, string[] vector)
    {
        WriteToDisk(fileName, vector, (w, o) => w.Write(o));
    }

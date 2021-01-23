    public static void RemoveDuplicateEntriesinFile(string filepath)
    {
        if (filepath == null)
            throw new ArgumentException("Please provide a valid FilePath");
        HashSet<string> hashSet = new HashSet<string>(File.ReadLines(filepath));
        File.WriteAllLines(filepath, hashSet);
    }

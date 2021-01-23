    string IndexedFilename(string stub, string extension) 
    {
        int ix = 0;
        string filename = null;
        do {
            ix++;
            filename = String.Format("{0}{1}.{2}", stub, ix, extension);
        } while (File.Exists(filename));
        return filename;
    }

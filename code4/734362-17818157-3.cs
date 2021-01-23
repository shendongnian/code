    static void Main()
    {
        string filename = @"e:\Test\test.dat";
        using (FileStream fs = NTFS.Sparse.SparseFile.Create(filename))
        {
            fs.Seek(1024 * 1024 * 100, SeekOrigin.Begin);
            fs.WriteByte(1);
        }
    }

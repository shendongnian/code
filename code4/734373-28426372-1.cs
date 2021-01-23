    class Program
    {
        static void Main(string[] args)
        {
            using (var fileStream = new FileStream("test", FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                fileStream.SetLength(1024 * 1024 * 128);
                fileStream.MakeSparse();
                fileStream.SetSparseRange(0, fileStream.Length);
            }
        }
    }

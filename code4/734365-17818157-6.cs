        static void Main()
        {
            string filename = @"e:\Test\test.dat";
            //Once a file is a sparse file it is always a sparse file, even if you open it using normal streams.
            using (FileStream fs = NTFS.Sparse.SparseFile.Create(filename)) 
            {
            }
            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                fs.Seek(1024 * 1024 * 100, SeekOrigin.Begin);
                fs.WriteByte(1);
            }
        }

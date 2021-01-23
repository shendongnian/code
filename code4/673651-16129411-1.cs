    class Program
    {
        static void Main(string[] args)
        {
            MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("MySharedMemory");
            MemoryMappedViewStream mmfvs = mmf.CreateViewStream();
            byte[] blen = new byte[4];
            mmfvs.Read(blen, 0, 4);
            int len = blen[0] + blen[1] * 256 + blen[2] * 65536 + blen[2] * 16777216;
            byte[] strbuf = new byte[len];
            mmfvs.Read(strbuf, 0, len);
            string s = System.Text.Encoding.Default.GetString(strbuf);
            Console.WriteLine(s);
        }
    }

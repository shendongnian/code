    static void Main(string[] args)
    {
        byte[] orig = new byte[] { 0x03, 0x18, 0x01 };
        byte[] target = new byte[] { 0x6F, 0x93, 0x8b };
        for (int i = 0; i < 256; ++i)
        {
            for (int j = 0; j < 256; ++j)
            {
                bool okay = true;
                for (int k = 0; okay && k < 3; ++k)
                {
                    byte tmp = (byte)((orig[k] ^ i) + j);
                    if (tmp != target[k]) { okay = false; break; }
                }
                if (okay)
                {
                    Console.WriteLine("Solution for i={0} and j={1}", i, j);
                }
            }
        }
        Console.ReadLine();
    }

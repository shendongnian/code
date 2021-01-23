    public static void Init2()
    {
        if (!File.Exists(fileName)) { throw new Exception("Handranks.dat not found"); }            
        BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open));            
        try
        {
            _lut = new int[maxSize];
            byte[] tempBuffer = new byte[maxSize * 4];
            Buffer.BlockCopy(tempBuffer, 0, _lut, 0, maxSize * 4);
        }
        finally
        {
            reader.Close();
        }
    }

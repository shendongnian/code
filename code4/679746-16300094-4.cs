    static byte[] bytes;
    static void Prep(TestStruct[] array)
    {
        int sizeOfT = Marshal.SizeOf(typeof(TestStruct));
        uint bytesToWrite = (uint)(array.Length * sizeOfT);
        bytes = new byte[bytesToWrite];
        for (int i = 0; i < array.Length; i++)
        {
            Buffer.BlockCopy(SerializeMessage<TestStruct>(array[i]), 0, bytes, i * sizeOfT, sizeOfT);
        }
    }
    public static Byte[] SerializeMessage<T>(T msg) where T : struct
    {
        int objsize = Marshal.SizeOf(typeof(T));
        Byte[] ret = new Byte[objsize];
        IntPtr buff = Marshal.AllocHGlobal(objsize);
        Marshal.StructureToPtr(msg, buff, true);
        Marshal.Copy(buff, ret, 0, objsize);
        Marshal.FreeHGlobal(buff);
        return ret;
    }
        
    static void SlowWrite(BinaryWriter writer, TestStruct[] array, int offset, int count)
    {
        writer.Write(bytes);
    }

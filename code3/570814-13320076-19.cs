    public static class ByteSerializer
    {
        public static Byte[] Serialize<T>(IEnumerable<T> msg) where T : struct
        {
            List<byte> res = new List<byte>();
            foreach (var s in msg)
            {
                res.AddRange(Serialize(s));
            }
            return res.ToArray();
        }
        public static Byte[] Serialize<T>(T msg) where T : struct
        {
            int objsize = Marshal.SizeOf(typeof(T));
            Byte[] ret = new Byte[objsize];
            IntPtr buff = Marshal.AllocHGlobal(objsize);
            Marshal.StructureToPtr(msg, buff, true);
            Marshal.Copy(buff, ret, 0, objsize);
            Marshal.FreeHGlobal(buff);
            return ret;
        }
    }
    class Program
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct Yours
        {
            public Int64 int1;
            public DateTime dt1;
            public float f1;
            public float f2;
            public float f3;
            public byte b;
        }
        static void Main()
        {
            var file = @"c:\temp\test.bin";
            IEnumerable<Yours> t = new Yours[3];
            File.WriteAllBytes(file, ByteSerializer.Serialize(t));
            using (var stream = File.OpenRead(file))
            {
                Console.WriteLine("file size: " + stream.Length);
            }
        }
    }

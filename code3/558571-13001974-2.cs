    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct UnionPacket2
    {
        [FieldOffset(0)]
        public float Time;
        [FieldOffset(4)]
        public Int16 CoordX;
        [FieldOffset(6)]
        public Int16 CoordY;
        [FieldOffset(8)]
        public byte Red;
        [FieldOffset(9)]
        public byte Green;
        [FieldOffset(10)]
        public byte Blue;
        [FieldOffset(11)]
        public byte Alpha;
    }
    static void Main(string[] args)
    {
        var len = Marshal.SizeOf(typeof(UnionPacket2));
        var buffer = new byte[len];
        for (byte i = 0; i < len; i++)
        {
            buffer[i] = i;
        }
        var ptr = Marshal.AllocHGlobal(len);
        Marshal.Copy(buffer, 0, ptr, len);
        var u = (UnionPacket2)Marshal.PtrToStructure(ptr, typeof(UnionPacket2));
        Marshal.FreeHGlobal(ptr);
        Console.WriteLine(u.Time);
        Console.WriteLine(u.CoordX);
        Console.WriteLine(u.CoordY);
        Console.WriteLine(u.Red);
        Console.WriteLine(u.Green);
        Console.WriteLine(u.Blue);
        Console.WriteLine(u.Alpha);
    }

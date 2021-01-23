    class Program
    {
        [DllImport("FatBoy.dll", SetLastError = true)]
        internal static extern IntPtr GetNearest();
        [StructLayout(LayoutKind.Sequential)]
        unsafe struct EntityValue
        {
            public ushort X, Y;
            public uint SERIAL;
            public ushort SpriteID;
            public byte DIRECTION;
            public ushort TYPE;
            public bool Cursed;
            public bool Fased;
            public bool IsPet;
        }
        static void Main(string[] args)
        {
            unsafe
            {
                EntityValue* data = (EntityValue*)GetNearest();
                Console.WriteLine(data->X);
                Console.WriteLine(data->Y);
                Console.WriteLine(data->SERIAL);
                Console.WriteLine(data->SpriteID);
                Console.WriteLine(data->DIRECTION);
                Console.WriteLine(data->TYPE);
                Console.WriteLine(data->Cursed);
                Console.WriteLine(data->Fased);
                Console.WriteLine(data->Fased);
            }
        }
    }

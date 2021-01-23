    public interface IBlock
    {
        RawBuffer Raw { get; }
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RawBuffer
    {
        public const int Count = 512;
        public const int Size = sizeof(byte) * Count;
        public fixed byte raw[Count];
        public void Initialize()
        {
            fixed (byte* ptr = raw)
            {
                for (int i = 0; i < Count; i++)
                {
                    ptr[i] = 0;
                }
            }
        }
    }
    [StructLayout(LayoutKind.Explicit, Size = RawBuffer.Size)]
    public unsafe struct RunBlock_t : IBlock
    {
        [FieldOffset(0)] public RawBuffer raw;
        [FieldOffset(0)] public UInt16 run_id; 
        [FieldOffset(2)] public UInt16 magic; 
        [FieldOffset(510)] public UInt16 checksum;
        public RunBlock_t(UInt32 sector)
        {
            raw.Initialize();
            run_id = 0;
            magic = 0;
            checksum = 0;            
        }
        public RawBuffer Raw { get { return raw; } }
    }
    [StructLayout(LayoutKind.Explicit, Size=RawBuffer.Size)]
    public unsafe struct RunBlock_s : IBlock
    {
        [FieldOffset(0)] public RawBuffer raw;
        [FieldOffset(0)] public UInt16 run_id;
        [FieldOffset(2)] public UInt32 soup;
        [FieldOffset(510)] public UInt16 checksum;
        public RunBlock_s(UInt32 sector)
        {
            raw.Initialize();
            run_id = 0;
            soup = 0;
            checksum = 0;            
        }
        public RawBuffer Raw { get { return raw; } }
    }
    class Program
    {
        public static T Factory<T>(UInt32 sector)
            where T : struct, IBlock
        {
            return (T)Activator.CreateInstance(typeof(T), sector);
        }
        static void Main(string[] args)
        {            
            var sw = Stopwatch.StartNew();
            var A = Factory<RunBlock_t>(0x20);
            long tic = sw.ElapsedTicks;
            Console.WriteLine("Initilized {0} in {1} cycles", A.GetType().Name, tic);
            // Initilized RunBlock_t in 1524 cycles
            sw = Stopwatch.StartNew();
            var B = Factory<RunBlock_s>(0x40);
            tic = sw.ElapsedTicks;
            Console.WriteLine("Initilized {0} in {1} cycles", B.GetType().Name, tic);
            // Initilized RunBlock_s in 722 cycles
        }
    }

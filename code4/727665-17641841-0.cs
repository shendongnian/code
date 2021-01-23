    using System;
    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Explicit)]
    public struct Chapter4Time
    {
        [FieldOffset(0)]
        public UInt16 Unused;
        [FieldOffset(2)]
        public UInt16 TimeHigh;
        [FieldOffset(4)]
        public UInt16 TimeLow;
        [FieldOffset(6)]
        public UInt16 MicroSeconds;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct IEEE_1588Time
    {
        [FieldOffset(0)]
        public UInt32 NanoSeconds;
        [FieldOffset(4)]
        public UInt32 Seconds;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct TimeUnion
    {
        [FieldOffset(0)]
        public Chapter4Time Chapter4Time;
        [FieldOffset(0)]
        public IEEE_1588Time IEEE_1588Time;
    }
    
    class Test
    {    
        static void Main()
        {
            var ch4 = new Chapter4Time { TimeLow = 100, MicroSeconds = 50 };
            var union = new TimeUnion { Chapter4Time = ch4 };
            Console.WriteLine(union.IEEE_1588Time.Seconds);
        }
    }

        [StructLayout(LayoutKind.Explicit)]
        private struct ConverterStruct2
        {
            [FieldOffset(0)] public ulong asLong;
            [FieldOffset(0)] public double asDouble;
        }
        // Same as Log2_SunsetQuest3 except
        public static int LeadingZeroCount(ulong val)
        {
            ConverterStruct2 a;  a.asLong = 0; a.asDouble = val;
            return 30-(int)((a.asLong >> 52)) & 0xFF;
        }

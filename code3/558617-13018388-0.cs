    [StructLayout(LayoutKind.Explicit)]
        public unsafe struct ListEntry {
            [System.Runtime.InteropServices.FieldOffset(0)] public fixed byte raw[512];
            [System.Runtime.InteropServices.FieldOffset(0)] public byte version;
            [System.Runtime.InteropServices.FieldOffset(1)] public UInt16 magic;
            [System.Runtime.InteropServices.FieldOffset(3)] public UInt32 start_time;
            [System.Runtime.InteropServices.FieldOffset(7)] public UInt16 run_id;
            [System.Runtime.InteropServices.FieldOffset(9)] public UInt16 channels;
            [System.Runtime.InteropServices.FieldOffset(11)] public UInt16 sampling_rate;
            [System.Runtime.InteropServices.FieldOffset(13)] public UInt32 start_sector;
            [System.Runtime.InteropServices.FieldOffset(510)] public UInt16 checksum;
        }

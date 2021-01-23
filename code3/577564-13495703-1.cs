    internal static class Device1
    {
        public static ushort PLACE_HOLDER1 = 0x0123;
        public static ushort PLACE_HOLDER2 = 0x0125;
        public static ushort PLACE_HOLDER_SAME_AS_1 = 0x0123;
        public static Dictionary<ushort, CParam> Registers;
        static Device1()
        {
            Registers = new Dictionary<ushort, CParam>()
                            {
                                {PLACE_HOLDER1, new CParam(() => PLACE_HOLDER1, "Place One Holder", 100)},
                                {PLACE_HOLDER2, new CParam(() => PLACE_HOLDER1, "Place Two Holder", 200)}
                            };
        }
    }

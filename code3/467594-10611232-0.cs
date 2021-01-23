    public static class Extensions
    {
        public static ulong ToDateStamp(this DateTime dt)
        {
            return (dt.Year << 20 | dt.Month << 16 | dt.Day << 11 | dt.Hour << 6 |                        dt.Minute);
        }
        public static DateTime FromDateStamp(this ulong stamp)
        {
            return new DateTime((stamp & 0xfff00000) >> 20,
                                (stamp & 0x000f0000) >> 16,
                                (stamp & 0x0000f800) >> 11,
                                (stamp & 0x000007c0) >> 6,
                                (stamp & 0x0000003f),
                                0 // 0 seconds
                               );
        }
    
    }

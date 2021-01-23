    public static class Ux {
        public static long ToUnixTimestampSecs(this DateTime date) => ToUnixTimestampTicks(date) / TimeSpan.TicksPerSecond;
        public static long ToUnixTimestampTicks(this DateTime date) => date.ToUniversalTime().Ticks - UnixEpochTicks;
        private static readonly long UnixEpochTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
    }

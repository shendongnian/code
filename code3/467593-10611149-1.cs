    public static class DateTimeExtensions
    {
        public static BitwiseDateStamp ToBitwiseDateStamp(this DateTime dt)
        {
            return new BitwiseDateStamp(dt);
        }
    }

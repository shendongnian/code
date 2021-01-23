    Putting it all together as an extension method:
        public static class DateTimeExtensions
        {
            public static ushort ToDosDateTime(this DateTime dateTime)
            {
                uint day = (uint)dateTime.Day;              // Between 1 and 31
                uint month = (uint)dateTime.Month;          // Between 1 and 12
                uint years = (uint)(dateTime.Year - 1980);  // From 1980
                if (years > 127)
                    throw new ArgumentOutOfRangeException("Cannot represent the year.");
                uint dosDateTime = 0;
                dosDateTime |= day << (16 - 16);
                dosDateTime |= month << (21 - 16);
                dosDateTime |= years << (25 - 16);
                return unchecked((ushort)dosDateTime);
            }
        }
        
    Of course you can write it more concise, but this shows clearly what's going on. And the compiler will optimize many of the constants.
    

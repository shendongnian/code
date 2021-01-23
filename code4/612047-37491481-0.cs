    public static class DateTimeExtensions
    {
        public static bool MinValue(this DateTime input)
        {
			// check the min values of .NET *and* VBA
            if (input == DateTime.MinValue || input == new DateTime(100, 1, 1))
            {
                return true;
            }
            return false;
        }
    }

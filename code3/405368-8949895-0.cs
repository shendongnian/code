        public static bool OneIsSet(Type enumType, byte value)
        {
            return Enum.GetValues(enumType).Cast<byte>().Count(v => (value & v) == v) == 1;
        }
        public static bool OneIsSet(Type enumType, int value)
        {
            return Enum.GetValues(enumType).Cast<byte>().Count(v => (value & v) == v) == 1;
        }

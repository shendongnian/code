     public static Dictionary<int, string> ToDictionary<T>()
        {
            var type = typeof (T);
            if (!type.IsEnum) throw new ArgumentException("Only Enum types allowed");
            return Enum.GetValues(type).Cast<Enum>().ToDictionary(value => (int) Enum.Parse(type, value.ToString()), value => value.ToString());
        }

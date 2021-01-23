        public static List<string> GetEnumList<T>()
        {
            // validate that T is in fact an enum
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException();
            }
            return Enum.GetNames(typeof(T)).ToList();
        }

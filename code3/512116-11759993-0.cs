        public static void PackEnumList<T>(IEnumerable<T> list) where T : IConvertible
        {
            foreach (var value in list)
                int numeric = value.ToInt32();
            // etc.
        }

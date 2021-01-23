        public static class Lists
        {
            public static List<T> New<T>(this List<T> list)
            {
                return new List<T>();
            }
        }
        ...
        ProtoTypes = ProtoTypes.New();

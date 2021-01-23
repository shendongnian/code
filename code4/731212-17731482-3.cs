        public static class Lists
        {
            public static List<T> New(this List<T> list)
            {
                return new List<T>();
            }
        }
        ...
        ProtoTypes = ProtoTypes.New();

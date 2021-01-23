        public static class Lists
        {
            public static void NewList(out List<T> list)
            {
                list = new List<T>();
            }
        }
        ...
        Lists.NewList(out ProtoTypes);

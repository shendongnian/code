        public static class Lists
        {
            public static void NewList<T>(out List<T> list)
            {
                list = new List<T>();
            }
        }
        ...
        Lists.NewList(out ProtoTypes);

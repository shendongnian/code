    class Type_of_m
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public static readonly IComparer<Type_of_m> NameDateComparer = new PrivateNameDateComparer();
        private class PrivateNameDateComparer : IComparer<Type_of_m>
        {
            public int Compare(Type_of_m x, Type_of_m y)
            {
                int comp = x.Name.CompareTo(y.Name);
                if (comp != 0) {
                    return comp;
                }
                return x.CreationTime.CompareTo(y.CreationTime);
            }
        }
        public static readonly IComparer<Type_of_m> DateNameComparer = new PrivateDateNameComparer();
        private class PrivateDateNameComparer : IComparer<Type_of_m>
        {
            public int Compare(Type_of_m x, Type_of_m y)
            {
                int comp = x.CreationTime.CompareTo(y.CreationTime);
                if (comp != 0) {
                    return comp;
                }
                return x.Name.CompareTo(y.Name);
            }
        }
    }

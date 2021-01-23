    class PartialEnum
    {
        private static readonly Dictionary<string, PartialEnum> Values =
            new Dictionary<string, PartialEnum>();
        public string Id { get; private set; }
        private PartialEnum(string id)
        {
            Id = id;
        }
        public static PartialEnum GetValue(string id)
        {
            PartialEnum value;
            if (!Values.TryGetValue(id, out value))
            {
                value = new PartialEnum(id);
            }
            return value;
        }
        public static PartialEnum Name { get { return GetValue("Name"); } }
        public static PartialEnum Group { get { return GetValue("Group"); } }
    }

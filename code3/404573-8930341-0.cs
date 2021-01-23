    namespace OGC.GML
    {
        public static class BasicTypes
        {
            public static Dictionary<string, int> SignType = new Dictionary<string, int>();
            static BasicTypes()
            {
                SignType.Add("-", 0);
                SignType.Add("+", 1);
            }
        }
    }

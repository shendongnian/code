    namespace OGC.GML.BasicTypes
    {
        public static class SignType
        {
            public static Dictionary<string, int> Values = new Dictionary<string, int>();
            static SignType()
            {
                Values.Add("-", 0);
                Values.Add("+", 1);
            }
        }
    }

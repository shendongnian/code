    public struct BetterString  // probably not better than System.String at all
    {
        public string Value { get; set; }
        public static BetterString operator *(BetterString s, int times)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < times; i++)
            {
                sb.Append(s.Value);
            }
            return new BetterString { Value = sb.ToString() };
        }
    }

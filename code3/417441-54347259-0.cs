    static class GuidConverter
    {
        public static string GuidToString(Guid g)
        {
            var bytes = g.ToByteArray();
            var sb = new StringBuilder();
            for (var j = 0; j < bytes.Length; j++)
            {
                var c = BitConverter.ToChar(bytes, j);
                sb.Append(c);
                j++;
            }
            return sb.ToString();
        }
        public static Guid StringToGuid(string s) 
            => new Guid(s.SelectMany(BitConverter.GetBytes).ToArray());
    }

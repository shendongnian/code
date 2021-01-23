    public static class StringExtensions
    {
        public static string MultiInsert(this string str, string insertChar, params int[] positions)
        {
            StringBuilder sb = new StringBuilder(str.Length + (positions.Count()*insertChar.Length));
            var posLookup = positions.ToDictionary(k => k);
            for(int i=0;i<str.Length;i++)
            {
                sb.Append(str[i]);
                if(posLookup.ContainsKey(i))
                    sb.Append(insertChar);
                    
            }
            return sb.ToString();
            
        }
    }

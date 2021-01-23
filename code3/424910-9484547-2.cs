    public static class StringExtensions
    {
        public static string MultiInsert(this string str, string insertChar, params int[] positions)
        {
            StringBuilder sb = new StringBuilder(str.Length + (positions.Length*insertChar.Length));
            var posLookup = new HashSet<int>(positions);
            for(int i=0;i<str.Length;i++)
            {
                sb.Append(str[i]);
                if(posLookup.Contains(i))
                    sb.Append(insertChar);
                    
            }
            return sb.ToString();
            
        }
    }

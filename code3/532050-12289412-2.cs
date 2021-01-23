    public static char[] SplitMeUp(this string str, char[] filterChars = null)
        {
            List<Char> chars = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if(filterChars != null && filterChars.Length > 0 && filterChars.Contains(str[i]))
                        continue; 
                chars.Add(str[i]);
            }
            return chars.ToArray();
        }

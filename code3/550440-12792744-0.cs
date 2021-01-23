        private string RemoveDuplicates(string s, char toRemove)
        {
            if (s.Length <= 1) return s;
            char s1,s2;
            string result="";
            result = s[0].ToString();
            s1 = s[0];
            for (int i = 0; i < s.Length-1; i++) 
            {
                
                s2 = s[i + 1];
                if ( s2.Equals(toRemove)&& s1.Equals(s2))
                {
                    s1 = s[i]; 
                    continue;
                }
                result += s2.ToString();
                s1 = s[i + 1];
           
            }
            return result;
        }

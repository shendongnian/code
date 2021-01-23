        public static bool isAnagram(String s, String t) {
            if(s.Length != t.Length) 
                return false;
            
            for(int i = 0; i < t.Length; i++)
            {
                var n = s.IndexOf(t[i]);
                if(n < 0)
                    return false;
                s = s.Remove(n, 1);
            }
            return String.IsNullOrEmpty(s);
        }

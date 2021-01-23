      public static bool check(string s, int index)
            {
              
                if (s.Length < 3)
                    return false;
    
                string left = s.Substring(0, index);
                Char[] rightChars = s.Substring(index + 1).ToCharArray();
                Array.Reverse(rightChars);
                    string right =new string (rightChars);
                    return left.Equals(right);
            }

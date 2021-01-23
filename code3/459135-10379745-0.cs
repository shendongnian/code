    public static int check(string s)
        {   
            if (s.Length < 3)
                return -1;
            for (int i = 0; i < s.Length - 1; i++)
            {
                left += s[i];
                right = s.Substring(i);
                char[] chars = left.ToCharArray();
                Array.Reverse(chars);
                string temp = new string(chars);
                if (temp.Equals(right))
                    return i;
            }
            return index;
        }

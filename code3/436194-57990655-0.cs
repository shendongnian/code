        public static bool IsPalindrome(string str)
        {
			int i = 0;
			int a = 0;
			char[] chr = str.ToCharArray();
            foreach (char cr in chr)
            {
                Array.Reverse(chr);
                if (chr[i] == cr)
                {
                    if (a == str.Length)
                    {
                        return true;
                    }
                    a++;
                    i++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

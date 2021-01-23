    public static bool palindrome(string t)
        {
            int i = t.Length;
            for (int j = 0; j < i / 2; j++)
            {
                if (t[j] == t[i - j-1])
                {
                    continue;
                }
                else
                {
                    return false;
                    break;
                }
            }
            return true;
        }

     public static bool IsPalindrome(string value)
            {
                int i = 0;
                int j = value.Length - 1;
                while (true)
                {
                    if (i > j)
                    {
                        return true;
                    }
                    char a = value[i];
                    char b = value[j];
                    if (char.ToLower(a) != char.ToLower(b))
                    {
                        return false;
                    }
                    i++;
                    j--;
                }
            }

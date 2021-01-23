     public static bool ContainsChar(this string input, params char[] characters)
            {
                foreach (var character in characters)
                {
                    if (input.Contains(character))
                    {
                        return true;
                    }
                }
                return false;
            }

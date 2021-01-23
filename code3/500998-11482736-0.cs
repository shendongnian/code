    public int CountChars(string value)
            {
                int result = 0;
                foreach (char c in value)
                {
                  if (c>127)
                    {
                        result = result + 10; // For Special Non ASCII Codes Like "ABCÀßĆʣʤʥ"
                    }
    
                    else
                    {
                        result++; // For Normal Characters Like "ABC"
                    }
                }
                return result;
            }

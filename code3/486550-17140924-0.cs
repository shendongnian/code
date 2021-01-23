        char[] TrimWhiteSpace(char[] source)
        {
            int i, j = 0;
            
            for (i = 0; i < source.Length; i++)
            {
                if (!char.IsWhiteSpace(source[i]))
                {
                    source[j] = source[i];
                    j++;
                }
            }
            for (int x = 0; x < (i - j); x++)
            {
                source[j + x] = '\0';
            }
            return source;
        }

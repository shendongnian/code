    int GetPos(string text)
        {
            int length = text.Length;
            for (int i = 0; i < length; i++)
            {
                if (GetChar(text, i) == ' ')
                {
                    return i;
                }
            }
            return -1;
        }
        int GetPos(StringBuilder sb)
        {
            int length = sb.Length;
            for (int i = 0; i < length; i++)
            {
                if (GetChar(sb, i) == ' ')
                {
                    return i;
                }
            }
            return -1;
        }
        char GetChar<T>(T text, int pos)
        {
            if (text.GetType() == typeof(StringBuilder))
            {
                return (text as StringBuilder)[pos];
            }
            else if (text.GetType() == typeof(String))
            {
                return (text as String)[pos];
            }
            else
            {
                throw new ArgumentException("Wrong parameter, T must be string or StringBuilder");
            }
        }

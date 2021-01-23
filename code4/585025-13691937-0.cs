    private static string FindRepeat(string str)
    {
        var lengths = Enumerable.Range(1, str.Length - 1)
            .Where(len => str.Length % len == 0);
        foreach (int len in lengths)
        {
            bool matched = true;
            for (int index = 0; matched && index < str.Length; index += len)
            {
                for (int i = index; i < index + len; ++i)
                {
                    if (str[i - index] != str[i])
                    {
                        matched = false;
                        break;
                    }
                }
            }
            if (matched)
                return str.Substring(0, len);
        }
        return str;
    }

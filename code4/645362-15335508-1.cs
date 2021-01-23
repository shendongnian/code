    public static bool HasConsecutiveSpaces(string text)
    {
        bool inSpace = false;
        foreach (char ch in text)
        {
            if (ch == ' ')
            {
                if (inSpace)
                {
                    return true;
                }
                inSpace = true;
            }
            else
            {
                inSpace = false;
            }
        }
        return false;
    }

    public bool CheckIfAllCharactersInAColumnAreTheSame (string[] lines, int colIndex)
    {
        char c = lines[0][colIndex];
        try
        {
            foreach (string s in lines)
            {
                if (s[colIndex] != c)
                {
                    return false;
                }
            }
            return true;
        }
        catch (IndexOutOfRangeException ex)
        {
            return false;
        }
    }

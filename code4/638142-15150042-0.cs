    static long GrabFirstLongFromString(string input)
    {
        string intAsString = String.Empty;
        bool startedInt = false;
        foreach(char c in input)
        {
            if (Char.IsDigit(c))
            {
                startedInt = true; //really only care about the first digit
                intAsString += c;
            }
            else if (startedInt)
                return long.Parse(intAsString);
        }
        return -1; //define a default, since this only does a 0 or positive I picked a negative
    }

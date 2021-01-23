    public static string RemoveSpaces(string arg)
    {
        int newLength = 0;
        //Calculate number of characters that arent spaces.
        foreach (char ch in arg)
        {
            if (ch != ' ')//If not a space,
            {
                newLength++;//then increment number of characters.
            }
        }
        //Now use that number as size in new array
        char[] newString = new char[newLength];
        //Copy characters that arent spaces to the new char array.
        int pos = 0;
        foreach (char ch in arg)
        {
            if (ch != ' ')//If element e is NOT a space,
            {
                newString[pos++] = ch;//then copy that element to newString.
            }
        }
        return new string(newString);//Done!
    }

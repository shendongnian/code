    static string RemovePath(string strInput)
    {
        int intLast = 0;
        for (int i = 1; i < strInput.Length; i++)
        {
            if (strInput.Substring(i, 1) == @"\")
            {
                intLast = i;
            }
        }
        string strOutput = strInput.Substring(strInput.Length - intLast);
        return strOutput;
    }

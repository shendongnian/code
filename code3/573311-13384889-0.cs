    static void Main(string[] args)
    {
        var values = new List<string>
        {"1 Some Street, Some Town, XYZ" ,
        "2 Some Street, Some Town, ABC" ,
        "3 Some Street, Some Town, XYZ" ,
        "4 Some Street, Some Town, ABC" };
        Console.WriteLine(LongestCommonSubstring(values));
        Console.ReadLine();
    }
    public static string LongestCommonSubstring(IList<string> values)
    {
        string result = string.Empty;
        for (int i = 0; i < values.Count - 1; i++)
        {
            for (int j = i + 1; j < values.Count; j++)
            {
                string tmp;
                if (LongestCommonSubstring(values[i], values[j], out tmp) > result.Length)
                {
                    result = tmp;
                }
            }
        }
        return result;
    }
    // Source: http://en.wikibooks.org/wiki/Algorithm_Implementation/Strings/Longest_common_substring
    public static int LongestCommonSubstring(string str1, string str2, out string sequence)
    {
        sequence = string.Empty;
        if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
            return 0;
        int[,] num = new int[str1.Length, str2.Length];
        int maxlen = 0;
        int lastSubsBegin = 0;
        StringBuilder sequenceBuilder = new StringBuilder();
        for (int i = 0; i < str1.Length; i++)
        {
            for (int j = 0; j < str2.Length; j++)
            {
                if (str1[i] != str2[j])
                    num[i, j] = 0;
                else
                {
                    if ((i == 0) || (j == 0))
                        num[i, j] = 1;
                    else
                        num[i, j] = 1 + num[i - 1, j - 1];
                    if (num[i, j] > maxlen)
                    {
                        maxlen = num[i, j];
                        int thisSubsBegin = i - num[i, j] + 1;
                        if (lastSubsBegin == thisSubsBegin)
                        {//if the current LCS is the same as the last time this block ran
                            sequenceBuilder.Append(str1[i]);
                        }
                        else //this block resets the string builder if a different LCS is found
                        {
                            lastSubsBegin = thisSubsBegin;
                            sequenceBuilder.Length = 0; //clear it
                            sequenceBuilder.Append(str1.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                        }
                    }
                }
            }
        }
        sequence = sequenceBuilder.ToString();
        return maxlen;
    }

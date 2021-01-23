    public static void StringTest()
    {
        string stringToUse = "Ala BalaB JiBBerish Ala Jibberish Ala BalaB";
        for (int i = 0; i < stringToUse.Length - 4; ++i)
        {
            if (stringToUse[i] == stringToUse[(i + 4)] &&
                stringToUse[(i + 1)] == stringToUse[(i + 3)])
            {
                Console.WriteLine(string.Join(string.Empty,
                    stringToUse[i],
                    stringToUse[i + 1],
                    stringToUse[i + 2],
                    stringToUse[i + 3],
                    stringToUse[i + 4]));
            }
        }
    }

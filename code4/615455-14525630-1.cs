    private static String Charset = "abcdefghijklmnopqrstuvwxyz";
    
    /// <summary>
    /// Start Brute Force.
    /// </summary>
    /// <param name="length">Words length.</param>
    public static void StartBruteForce(int length)
    {
        StringBuilder sb = new StringBuilder(length);
        char currentChar = Charset[0];
    
        for (int i = 1; i <= length; i++)
        {
            sb.Append(currentChar);
        }
    
        int counter = 0;
    
        var resumePoint = 60975;
    
        ChangeCharacters(0, sb, length, ref counter, resumePoint);
    
        Console.WriteLine(counter);
    }
    
    private static void ChangeCharacters(int pos, StringBuilder sb, int length, ref int counter, int resumePoint)
    {
        for (int i = 0; i <= Charset.Length - 1; i++)
        {
            sb[pos] = Charset[i];
            if (pos == length - 1)
            {
                counter++;
                if (counter >= resumePoint)
                {
                    Console.WriteLine(string.Format("{0} : {1}", counter, sb.ToString()));
                }
            }
            else
            {
                ChangeCharacters(pos + 1, sb, length, ref counter, resumePoint);
            }
        }
    }

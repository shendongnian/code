    private static string RemoveNonAlpha(string value)
    {
        char[] output = new char[value.Length];
        int numAlpha = 0;
        byte charCode = 0;
        for (int i = 0; i < value.Length; i++)
        {
            charCode = (byte)value[i];
            if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122))
            {
                output[numAlpha] = value[i];
                numAlpha++;
            }
        }
    
        return new string(output, 0, numAlpha);
    }

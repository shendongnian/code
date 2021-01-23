    public static int IndexOfWithCount(this string input, char character, int occurenceNumber)
    {
        int count = 0;
        for (int numCaracter = 0; numCaracter < input.Length; numCaracter++)
            if (input[numCaracter] == character)
            {
                count++;
                if (count == occurenceNumber)
                    return numCaracter;
            }
        return -1;
    }

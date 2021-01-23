    private static string GenerateMask(string mask)
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < mask.Length; i++)
        {
            if (mask[i] == 'd' && mask[i - 1] != '\\')
            {
                int quantifier = 1;
    
                if (mask[i + 1] == ':')
                    Int32.TryParse(mask[i + 2].ToString(), out quantifier);
    
                output.Append(GetRandomDigit(quantifier));
                i += 2;
            }
            else
            {
                if(mask[i] != '\\')
                output.Append(mask[i]);
            }
        }
    
        return output.ToString();
    }
    
    private static string GetRandomDigit(int length)
    {
        Random random = new Random();
        StringBuilder output = new StringBuilder();
        while (output.Length != length)
            output.Append(random.Next(0, 9));
        return output.ToString();
    }

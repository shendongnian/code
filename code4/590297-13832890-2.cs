    private string EncryptFn(string Sinput)
    {
        string coding = "QWERTYUIOPASDFGHJKLZXCVBNM";
        StringBuilder result = new StringBuilder();
        foreach (char c in Sinput)
        {
            int index = (Char.ToUpper(c) - 'A');
            if (index >= 0 && index < coding.Length)
                result.Append(coding[index]);
            else
                result.Append(c);
        }
        return result.ToString();
    }

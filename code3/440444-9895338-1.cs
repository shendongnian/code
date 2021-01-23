    string RemoveNonAlpha(string value)
    {
        byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < asciiBytes.Length; i++)
        {
            if((asciiBytes[i] >= 65 && asciiBytes[i] <= 90) || (asciiBytes[i] >= 97 && asciiBytes[i] <= 122))
            {
                sb.Append(alphabet[asciiBytes[i]]);
            }
        }
        
        return sb.ToString();
    }

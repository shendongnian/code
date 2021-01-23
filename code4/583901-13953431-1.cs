    public static string RemoveDiacritics(string text)
    {
        Encoding srcEncoding = Encoding.UTF8;
        Encoding destEncoding = Encoding.GetEncoding(1252); // Latin alphabet
    
        text = destEncoding.GetString(Encoding.Convert(srcEncoding, destEncoding, srcEncoding.GetBytes(text)));
    
        string normalizedString = text.Normalize(NormalizationForm.FormD);
        StringBuilder result = new StringBuilder();
    
        for (int i = 0; i < normalizedString.Length; i++)
        {
            if (!CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]).Equals(UnicodeCategory.NonSpacingMark))
            {
                result.Append(normalizedString[i]);
            }
        }
    
        return result.ToString();
    }

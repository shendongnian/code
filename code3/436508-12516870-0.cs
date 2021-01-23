    public static string SanitiseSerialisedXml(this string serialized)
    {
        if (serialized == null)
        {
            return null;
        }
    
        const string pattern = @"&#x([0-9A-F]{1,2});";
    
        var sanitised = Regex.Replace(serialized, pattern, match =>
        {
            var value = match.Groups[1].Value;
    
            int characterCode;
            if (int.TryParse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out characterCode))
            {
                if (characterCode >= char.MinValue && characterCode <= char.MaxValue)
                {
                    return XmlConvert.IsXmlChar((char)characterCode) ? match.Value : string.Empty;
                }
            }
    
            return match.Value;
        });
    
        return sanitised;
    }

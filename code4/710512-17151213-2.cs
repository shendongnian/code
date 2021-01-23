    public static bool IsStringValidForCodePage(string text, int codePage)
    {
        var encoder = Encoding.GetEncoding(codePage, new EncoderExceptionFallback(), new DecoderExceptionFallback());
        try
        {
            encoder.GetBytes(text);
        }
        catch (EncoderFallbackException)
        {
            return false;
        }
        return true;
    }

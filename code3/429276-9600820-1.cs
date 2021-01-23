    /// <summary>
    /// The method create a Base64 encoded string from a normal string.
    /// </summary>
    /// <param name="toEncode">The String containing the characters to encode.</param>
    /// <returns>The Base64 encoded string.</returns>
    public static string EncodeTo64(string toEncode)
    {
    
        byte[] toEncodeAsBytes
    
              = System.Text.Encoding.Unicode.GetBytes(toEncode);
    
        string returnValue
    
              = System.Convert.ToBase64String(toEncodeAsBytes);
    
        return returnValue;
    
    }

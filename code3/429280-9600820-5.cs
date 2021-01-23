    /// <summary>
    /// The method to Decode your Base64 strings.
    /// </summary>
    /// <param name="encodedData">The String containing the characters to decode.</param>
    /// <returns>A String containing the results of decoding the specified sequence of bytes.</returns>
    public static string DecodeFrom64(string encodedData)
    {
    
        byte[] encodedDataAsBytes
    
            = System.Convert.FromBase64String(encodedData);
    
        string returnValue =
    
           System.Text.Encoding.Unicode.GetString(encodedDataAsBytes);
    
        return returnValue;
    
    }

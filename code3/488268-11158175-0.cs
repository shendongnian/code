    /// <summary>
    /// Hex2s the octal.
    /// </summary>
    /// <param name="hexvalue">The hexvalue.</param>
    /// <returns></returns>
    public static string hex2Octal(string hexvalue)
    {
       string binaryval = "";
       binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 8);
       return binaryval;
    }

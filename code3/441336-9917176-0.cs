    public static string BitStringFromHexString(string hex)
    {
        int i;
        if (!Int32.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out i))
        {
            throw new ArgumentException(String.Format("Input not recognized '{0}'. ", hex), "hex");
        }
        
        return Convert.ToString(i,2);
     }

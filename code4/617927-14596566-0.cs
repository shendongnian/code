    public static string ConvertToHex(byte[] bytes)
    {
     	SoapHexBinary hexBin = new SoapHexBinary(bytes);
       	return hexBin.ToString();
    }
    return ConvertToHex(TRIGGER_POL.ToArray());

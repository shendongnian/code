    using System.Runtime.Remoting.Metadata.W3cXsd2001;
    
    public byte[] StringToBytes(string value)
    {
        SoapHexBinary soapHexBinary = SoapHexBinary.Parse(value);
        return soapHexBinary.Value;
    }
    
    public string BytesToString(byte[] value)
    {
        SoapHexBinary soapHexBinary = new SoapHexBinary(value);
        return soapHexBinary.ToString();
    }

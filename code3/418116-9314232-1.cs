    private byte[] ConvertToBytes(string text)
    {
        int len = text.Length;
        byte[] b = new byte[len];
        for (int k = 0; k < len; ++k)
            b[k] = (byte)text[k];
        return b;
    }
    
    Encoding encoding = Encoding.GetEncoding(1255);
    ...
    if (!datareader.IsDBNull(i))
    {
        string value = dataReader.GetString(i);
        if (value.Length > 0)
        {
            byte[] bytes = ConvertToBytes(value);
            value = m_DatabaseEncoding.GetString(bytes);
        }
        // store value
     }

    Encoding encoding = Encoding.GetEncoding(1255);
    ...
    if (!datareader.IsDBNull(i))
    {
        string value = dataReader.GetString(i);
        if (value.Length > 0)
        {
            byte[] bytes = Encoding.Default.GetBytes(value);
            value = m_DatabaseEncoding.GetString(bytes);
        }
        // store value
     }

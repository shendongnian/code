    void CopyStringToField(string value, sbyte[] field)
    {
        int maxLength = field.Length;  // or field.Length - 1 if you need room for null terminator
        byte[] fieldValue = Encoding.ASCII.GetBytes(value);
        if (fieldValue.Length > maxLength)
            throw new ArgumentException("string too long for field.");
        int length = Math.Min(fieldValue.Length, maxLength);
        Array.Copy(fieldValue, 0, field, 0, length);
        // zero fill remaining bytes
        for (int i = length; i < field.Length; i++)
        {
            field[i] = 0;
        }
    }
    

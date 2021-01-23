    public static unsafe string Join(string separator, string[] value, int startIndex, int count)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
        }
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
        }
        if (startIndex > (value.Length - count))
        {
            throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
        }
        if (separator == null)
        {
            separator = Empty;
        }
        if (count == 0)
        {
            return Empty;
        }
        int length = 0;
        int num2 = (startIndex + count) - 1;
        for (int i = startIndex; i <= num2; i++)
        {
            if (value[i] != null)
            {
                length += value[i].Length;
            }
        }
        length += (count - 1) * separator.Length;
        if ((length < 0) || ((length + 1) < 0))
        {
            throw new OutOfMemoryException();
        }
        if (length == 0)
        {
            return Empty;
        }
        string str = FastAllocateString(length);
        fixed (char* chRef = &str.m_firstChar)
        {
            UnSafeCharBuffer buffer = new UnSafeCharBuffer(chRef, length);
            buffer.AppendString(value[startIndex]);
            for (int j = startIndex + 1; j <= num2; j++)
            {
                buffer.AppendString(separator);
                buffer.AppendString(value[j]);
            }
        }
        return str;
    }

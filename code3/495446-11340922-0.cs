    string ReverseString(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            char[] newBuffer = new char[value.Length];
            for(int i = 0; i < value.Length; i++)
                newBuffer[newBuffer.Length - i - 1] = value[i];
            value = new string(newBuffer);
        }
        return value;
    }

    public int GetValue(string text)
    {
        Test t;
        if (Enum.TryParse(text, out t)
            return (int)t;       
        // throw exception or return a default value
    }

    bool IsTextAValidIPAddress(string text)
    {
        bool result = true;
        string[] values = text.Split(new[] { "." }, StringSplitOptions.None); //keep empty strings when splitting
        result &= values.Length == 4; // aka string has to be like "xx.xx.xx.xx"
        if(result)
            for (int i = 0; i < 4; i++) 
                result &= byte.TryParse(values[i], out temp); //each "xx" must be a byte (0-255)
        return result;
    }

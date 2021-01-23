    public int makeHex(string str)
    {
        return (int.Parse(str, System.Globalization.NumberStyles.HexNumber));
    }
    ....
    for (int i = 0; i < int.MaxValue; i++)
        if (ReadMemory(makeHex(i.ToString()), 1) == memory)

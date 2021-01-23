    public List<bool> ReadBits(int Value)
    {
        if (Value == 0)
        {
            List<bool> Result = new List<bool>();
        }
        else
        {
            List<bool> Result = ReadBits(value - 1);
            Result.Add(ReadBit());
        }
        return Result;
    }

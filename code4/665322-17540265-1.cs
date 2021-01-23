    public decimal? ReadNullableDecimal()
    {
        bool hasValue = ReadBoolean();
        if (hasValue) return ReadDecimal();
        return null;
    }
    public void Write(decimal? val)
    {
        bool hasValue = val.HasValue;
        Write(hasValue)
        if(hasValue)
            Write(val.Value);
    }

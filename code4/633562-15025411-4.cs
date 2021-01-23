    public static short ConvertToShort(int value)
    {
        short result;
        if (value > Int16.MinValue && value < Int16.MaxValue)
        {
            result = Convert.ToInt16(value);
        }
        else
        {
            throw new OverflowException();
        }
        
        return result;
    }

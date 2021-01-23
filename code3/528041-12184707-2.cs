    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public int CompareTo(int value)
    {
        if (this < value)
        {
            return -1;
        }
        if (this > value)
        {
            return 1;
        }
        return 0;
    }
    public int CompareTo(object value)
    {
        if (value == null)
        {
            return 1;
        }
        if (!(value is int))
        {
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeInt32"));
        }
        int num = (int) value;
        if (this < num)
        {
            return -1;
        }
        if (this > num)
        {
            return 1;
        }
        return 0;
    }

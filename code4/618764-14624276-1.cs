    public static bool IsExactlyOne(object n)
    {
    bool result = false;
    try
    {
    result = Convert.ToDouble(n) == 1.0;
    }
    catch
    {
    }
    return result;
    }
